using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            cRUD = new AccionesCRUD();
            InitializeComponent();
            this.LlenarEstado();
            this.LlenarTodoList();
            this.txt_estado.SelectedIndex = 0;
            this.BTN_ACTUALIZAR.Enabled = false;
            this.BTN_ELIMINAR.Enabled = false;
            this.button1.Enabled = false;
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

        async Task LlenarTodoListPendiente()
        {
            this.ListPendientes.Items.Clear();
            try
            {
                var tareas = await cRUD.Mostrar();
                foreach (var item in tareas.Where(p => p.Estado == Estado.Pendiente.ToString()))
                {
                    this.ListPendientes.Items.Add(item.Nombre);
                }
            }
            catch
            {
                MessageBox.Show("Ocurrio un error y no se pueden mostrar las tareas.");
            }
        }


        private async void BTN_GUARDAR_Click(object sender, EventArgs e)
        {
            try
            {
                txt_nombre.Enabled = true;
                //Rectificar que la fecha final no sea igual o menor a la fecha inicial.
                if (txt_fecha_inicio.Value < txt_fecha_final.Value)
                {
                    var AgregarDto = new NotasAgregarDto()
                    {
                        Nombre = txt_nombre.Text,
                        Fecha_Inicio = txt_fecha_inicio.Value,
                        Fecha_Final = txt_fecha_final.Value,
                        Estado = (Estado)Enum.Parse(typeof(Estado), txt_estado.SelectedItem.ToString()),
                        Cuerpo = txt_cuerpo.Text
                    };
                    if (await cRUD.Agregar(AgregarDto))
                    {
                        notifyIcon1.Icon = SystemIcons.Information;
                        notifyIcon1.ShowBalloonTip(100, "", "Agregado correctamente", ToolTipIcon.Info);
                        await this.LlenarTodoList();
                    }
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
                    var tarea = await cRUD.Mostrar();
                    var tareaEncontrada = tarea.FirstOrDefault(p => p.Nombre == tareaSeleccionada);

                    if(tareaEncontrada != null)
                    {
                        txt_nombre.Text = tareaEncontrada.Nombre;
                        txt_fecha_inicio.Value = tareaEncontrada.Fecha_Inicio;
                        txt_fecha_final.Value = tareaEncontrada.Fecha_Final;
                        txt_estado.Text = tareaEncontrada.Estado;
                        txt_cuerpo.Text = tareaEncontrada.Cuerpo;
                        this.BTN_ACTUALIZAR.Enabled = true;
                        this.BTN_ELIMINAR.Enabled = true;
                        this.button1.Enabled = true;
                    }
                    else
                    {
                        notifyIcon1.Icon = SystemIcons.Information;
                        notifyIcon1.ShowBalloonTip(100, "", "No se encontro", ToolTipIcon.Warning);
                    }
                }
                else
                    MessageBox.Show("La fecha final no puede ser menor o igual a la fecha inicial! " +
                        "Incluyendo la hora.");
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

                //Rectificar que la fecha final no se igual o menor a la fecha inicial.
                if (txt_fecha_inicio.Value < txt_fecha_final.Value)
                {
                    var AgregarDto = new NotasActualizarDto()
                    {
                        ID = tareaEncontrada.ID,
                        Nombre = txt_nombre.Text,
                        Fecha_Inicio = txt_fecha_inicio.Value,
                        Fecha_Final = txt_fecha_final.Value,
                        Estado = (Estado)Enum.Parse(typeof(Estado), txt_estado.SelectedItem.ToString()),
                        Cuerpo = txt_cuerpo.Text
                    };
                    if (await cRUD.Actualizar(AgregarDto))
                    {
                        notifyIcon1.Icon = SystemIcons.Information;
                        notifyIcon1.ShowBalloonTip(100, "", "Actualizado correctamente", ToolTipIcon.Info);
                        await this.LlenarTodoList();
                    }
                }
                else
                    MessageBox.Show("La fecha final no puede ser menor o igual a la fecha inicial! " +
                        "Incluyendo la hora.");

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
                DialogResult result = MessageBox.Show("¿Estás seguro de eliminar esta tarea?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (await cRUD.Eliminar(tareaEncontrada.ID))
                    {
                        await this.LlenarTodoList();
                        notifyIcon1.Icon = SystemIcons.Information;
                        txt_cuerpo.Clear();
                        txt_nombre.Clear();
                        txt_fecha_inicio.ResetText();
                        txt_fecha_final.ResetText();
                        txt_estado.SelectedIndex = 0;
                        this.BTN_ELIMINAR.Enabled = false;
                        this.BTN_GUARDAR.Enabled = false;
                        this.button1.Enabled = false;
                        notifyIcon1.ShowBalloonTip(100, "", "Eliminado correctamente", ToolTipIcon.Info);
                    }
                    else
                    {
                        notifyIcon1.Icon = SystemIcons.Warning;
                        notifyIcon1.ShowBalloonTip(100, "", "No se Elimino", ToolTipIcon.Warning);
                        await this.LlenarTodoList();
                    }
                }
            }
            catch
            {
                notifyIcon1.Icon = SystemIcons.Warning;
                notifyIcon1.ShowBalloonTip(100, "", "No se Elimino", ToolTipIcon.Warning);
                await this.LlenarTodoList();
            }
        }

        private async void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 1)
            {
                await this.LlenarTodoListPendiente();
            }
        }

        private async void ListPendientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txt_nombre.Enabled = false;
                if (ListPendientes.SelectedIndex != -1)
                {
                    string tareaSeleccionada = ListPendientes.Text;
                    var tarea = await cRUD.Mostrar();
                    var tareaEncontrada = tarea.FirstOrDefault(p => p.Nombre == tareaSeleccionada);

                    if (tareaEncontrada != null)
                    {
                        txt_nombre.Text = tareaEncontrada.Nombre;
                        txt_fecha_inicio.Value = tareaEncontrada.Fecha_Inicio;
                        txt_fecha_final.Value = tareaEncontrada.Fecha_Final;
                        txt_estado.Text = tareaEncontrada.Estado;
                        txt_cuerpo.Text = tareaEncontrada.Cuerpo;
                        this.BTN_ACTUALIZAR.Enabled = true;
                        this.BTN_ELIMINAR.Enabled = true;
                        this.button1.Enabled = true;
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

        [STAThread]
        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt";
            saveFileDialog.FileName = txt_nombre.Text;
            saveFileDialog.Title = "Guardar tarea como";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string ruta = saveFileDialog.FileName;
                string contenido = $"Título: {txt_nombre.Text}\n" +
                    $"Fecha inicial: {txt_fecha_inicio.Value} \n" +
                    $"Fecha límite: {txt_fecha_final.Value}\n" +
                    $"Estado: {txt_estado.Text}\n\n" +
                    $"{txt_cuerpo.Text}";

                File.WriteAllText(ruta, contenido);
                MessageBox.Show("Archivo guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
