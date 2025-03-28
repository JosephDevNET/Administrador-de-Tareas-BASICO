using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AplicacionTareas.Acciones;
using AplicacionTareas.Dtos;
using AplicacionTareas.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AplicacionTareas
{
    public partial class Form1 : Form
    {
        private AccionesCRUD cRUD;
        public Form1()
        {
            InitializeComponent();
            this.LlenarEstado();
            this.LlenarTodoList();
        }
        
        void LlenarEstado()
        {
            var estados = Enum.GetValues(typeof(Estado));
            foreach(var item in estados)
            {
                this.txt_estado.Items.Add(item);
            }
            txt_estado.SelectedItem = 0;
        }

        async Task LlenarTodoList()
        {
            this.listBox1.Items.Clear();
            try
            {
                cRUD = new AccionesCRUD();
                foreach(var item in await cRUD.Mostrar())
                {
                    this.listBox1.Items.Add(item.Nombre);
                }
            }
            catch
            {
                MessageBox.Show("Ocurrio un error y no se pueden mostrar las notas.");
            }
        }

        private async void BTN_GUARDAR_Click(object sender, EventArgs e)
        {
            try
            {
                txt_nombre.Enabled = true;
                var AgregarDto = new NotasAgregarDto()
                {
                    Nombre = txt_nombre.Text,
                    Fecha_Inicio = txt_fecha_inicio.Value,
                    Fecha_Final = txt_fecha_final.Value,
                    Estado = (Estado)Enum.Parse(typeof(Estado), txt_estado.SelectedItem.ToString()),
                    Cuerpo = txt_cuerpo.Text
                };
                cRUD = new AccionesCRUD();
                if(await cRUD.Agregar(AgregarDto))
                {
                    notifyIcon1.Icon = SystemIcons.Information;
                    notifyIcon1.ShowBalloonTip(100 , "" , "Agregado correctamente" , ToolTipIcon.Info);
                    await this.LlenarTodoList();
                }

            }
            catch
            {
                notifyIcon1.Icon = SystemIcons.Warning;
                notifyIcon1.ShowBalloonTip(100, "", "No se agrego", ToolTipIcon.Warning);
                await this.LlenarTodoList();

            }

        }

        private async void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txt_nombre.Enabled = false;
                if (listBox1.SelectedIndex != -1)
                {
                    string tareaSeleccionada = listBox1.Text;
                    cRUD = new AccionesCRUD();
                    var tarea = await cRUD.Mostrar();
                    var tareaEncontrada = tarea.FirstOrDefault(p => p.Nombre == tareaSeleccionada);

                    if(tareaEncontrada != null)
                    {
                        txt_nombre.Text = tareaEncontrada.Nombre;
                        txt_fecha_inicio.Value = tareaEncontrada.Fecha_Inicio;
                        txt_fecha_final.Value = tareaEncontrada.Fecha_Final;
                        txt_estado.Text = tareaEncontrada.Estado;
                        txt_cuerpo.Text = tareaEncontrada.Cuerpo;
                    }
                    else
                    {
                        notifyIcon1.Icon = SystemIcons.Information;
                        notifyIcon1.ShowBalloonTip(100, "", "No se encontro", ToolTipIcon.Warning);
                    }
                }
            }
            catch
            {
                notifyIcon1.Icon = SystemIcons.Warning;
                notifyIcon1.ShowBalloonTip(100, "", "No se encontro", ToolTipIcon.Warning);

            }
        }

        private async void BTN_ACTUALIZAR_Click(object sender, EventArgs e)
        {
            try
            {
                var tarea = await cRUD.Mostrar();
                var tareaEncontrada = tarea.FirstOrDefault(p => p.Nombre == txt_nombre.Text);

                var AgregarDto = new NotasActualizarDto()
                {
                    ID = tareaEncontrada.ID,
                    Nombre = txt_nombre.Text,
                    Fecha_Inicio = txt_fecha_inicio.Value,
                    Fecha_Final = txt_fecha_final.Value,
                    Estado = (Estado)Enum.Parse(typeof(Estado), txt_estado.SelectedItem.ToString()),
                    Cuerpo = txt_cuerpo.Text
                };
                cRUD = new AccionesCRUD();
                if (await cRUD.Actualizar(AgregarDto))
                {
                    notifyIcon1.Icon = SystemIcons.Information;
                    notifyIcon1.ShowBalloonTip(100, "", "Actualizado correctamente", ToolTipIcon.Info);
                    await this.LlenarTodoList();
                }

            }
            catch
            {
                notifyIcon1.Icon = SystemIcons.Warning;
                notifyIcon1.ShowBalloonTip(100, "", "No se Actualizo", ToolTipIcon.Warning);
                await this.LlenarTodoList();

            }
        }

        private async void BTN_ELIMINAR_Click(object sender, EventArgs e)
        {
            try
            {
                var tarea = await cRUD.Mostrar();
                var tareaEncontrada = tarea.FirstOrDefault(p => p.Nombre == txt_nombre.Text);
                
                cRUD = new AccionesCRUD();
                if (await cRUD.Eliminar(tareaEncontrada.ID))
                {
                    await this.LlenarTodoList();
                    notifyIcon1.Icon = SystemIcons.Information;
                    notifyIcon1.ShowBalloonTip(100, "", "Eliminado correctamente", ToolTipIcon.Info);
                }
                else
                {
                    notifyIcon1.Icon = SystemIcons.Warning;
                    notifyIcon1.ShowBalloonTip(100, "", "No se Elimino", ToolTipIcon.Warning);
                    await this.LlenarTodoList();
                }
            }
            catch
            {
                notifyIcon1.Icon = SystemIcons.Warning;
                notifyIcon1.ShowBalloonTip(100, "", "No se Elimino", ToolTipIcon.Warning);
                await this.LlenarTodoList();
            }
        }
    }
}
