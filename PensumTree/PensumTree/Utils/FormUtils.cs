using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace PensumTree.Utils
{
    //En esta clase habrá una colección de métodos que puedan ser de utilidad para uso en cualquier form

    static class FormUtils
    {
        /// <summary>
        /// Oculta las columnas de un datagrid
        /// </summary>
        /// <param name="columnsToHide">Un array conteniendo los ID de las columnas a ocultar</param>
        /// <param name="dgv">El datagrid cuyas columnas serán ocultadas</param>
        public static void hideColumnsForDgv(int[] columnsToHide, DataGridView dgv)
        {
             foreach(int column in columnsToHide)
                dgv.Columns[column].Visible = false;
        }

        /// <summary>
        /// Cambia los títulos de las columnas de un datagrid
        /// </summary>
        /// <param name="titles">Un array conteniendo los títulos de cada una de las columnas que se cambiarán</param>
        /// <param name="columnsToChange">Un array conteniendo los ID de las columnas a cambiar, en el mismo 
        /// orden en el que se especificaron los títulos</param>
        /// <param name="dgv">El datagrid cuyos títulos serán cambiados</param>
        public static void changeTitlesForDgv(string[] titles, int[] columnsToChange, DataGridView dgv)
        {
            if (!(titles.Length == columnsToChange.Length))
                throw new Exception("The size of titles and columnsToChange not are equals");

            for (int i = 0; i < titles.Length; i++)
                dgv.Columns[columnsToChange[i]].HeaderText = titles[i];
        }

        /// <summary>
        /// Limpia todos los textbox proveidos
        /// </summary>
        /// <param name="controls">Array conteniendo los textbox a limpiar</param>
        public static void clearTextbox(Control[] controls)
        {
            foreach(Control c in controls)
            {
                if(c is TextBox)
                {
                    c.Text = "";
                }
            }
        }


        /// <summary>
        /// Mensaje de error por defecto. Llamar este método en cada instancia en la que se produzca
        /// una excepción no controlada que no deba ser vista por el usuario
        /// </summary>
        /// <param name="ex">La excepción generada</param>
        /// <returns></returns>
        public static DialogResult defaultErrorMessage(Exception ex)
        {
            return MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

      
    }
}
