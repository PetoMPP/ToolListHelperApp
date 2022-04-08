using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolListHelperUI
{
    internal class ApplicationThemes
    {
        public static Color DarkPrimaryFore { get; } = Color.FromArgb(30, 165, 235);
        public static Color DarkSecondaryFore { get; } = Color.White;
        public static Color DarkPrimaryBack { get; } = Color.FromArgb(66, 66, 66);
        public static Color DarkSecondaryBack { get; } = Color.FromArgb(20, 100, 135);
        public static Color DarkPrimaryBorderColor { get; } = Color.Black;
        public static Color DarkSecondaryBorderColor { get; } = Color.FromArgb(30, 165, 235);
        public static Color DarkActiveButtonColor { get; } = Color.FromArgb(99, 99, 99);
        public static Color DarkRedFore { get; } = Color.FromArgb(255, 0, 0);
        public static Color DarkGreenFore { get; } = Color.FromArgb(0, 255, 0);
        public static Color DarkPurpleFore { get; } = Color.FromArgb(200, 200, 255);
        public static Color DarkBlueFore { get; } = Color.FromArgb(99, 99, 255);
        public static Color LightPrimaryFore { get; } = Color.FromArgb(1, 112, 184);
        public static Color LightSecondaryFore { get; } = Color.Black;
        public static Color LightPrimaryBack { get; } = Color.White;
        public static Color LightSecondaryBack { get; } = Color.FromArgb(30, 165, 235);
        public static Color LightPrimaryBorderColor { get; } = Color.White;
        public static Color LightSecondaryBorderColor { get; } = Color.FromArgb(1, 60, 111);
        public static Color LightActiveButtonColor { get; } = Color.Gainsboro;
        public static Color LightRedFore { get; } = Color.FromArgb(192, 0, 0);
        public static Color LightGreenFore { get; } = Color.FromArgb(0, 192, 0);
        public static Color LightPurpleFore { get; } = Color.FromArgb(128, 128, 255);
        public static Color LightBlueFore { get; } = Color.FromArgb(0, 0, 255);
        public static void ApplyTheme(Form form, ApplicationTheme applicationTheme)
        {
            switch (applicationTheme)
            {
                case ApplicationTheme.Light:
                    form.BackColor = LightPrimaryBack;
                    foreach (Label label in UserInterfaceLogic.GetAllControls<Label>(form))
                    {
                        label.ForeColor = LightPrimaryFore;
                    }
                    foreach (RadioButton radio in UserInterfaceLogic.GetAllControls<RadioButton>(form))
                    {
                        radio.ForeColor = LightSecondaryFore;
                    }
                    foreach (TextBox textBox in UserInterfaceLogic.GetAllControls<TextBox>(form))
                    {
                        textBox.ForeColor = LightSecondaryFore;
                        textBox.BackColor = LightSecondaryBack;
                    }
                    foreach (Button button in UserInterfaceLogic.GetAllControls<Button>(form).Where(b => b.Tag?.ToString() != "UnchangeableColor"))
                    {
                        button.ForeColor = button.Tag?.ToString() switch
                        {
                            "ColorfulForeGreen" => LightGreenFore,
                            "ColorfulForeRed" => LightRedFore,
                            "ColorfulForePurple" => LightPurpleFore,
                            "ColorfulForeBlue" => LightBlueFore,
                            _ => LightPrimaryFore
                        };
                        button.BackColor = LightPrimaryBack;
                        button.FlatAppearance.BorderColor = button.Tag?.ToString() switch
                        {
                            "ColorfulForeGreen" => LightGreenFore,
                            "ColorfulForeRed" => LightRedFore,
                            "ColorfulForePurple" => LightPurpleFore,
                            "ColorfulForeBlue" => LightBlueFore,
                            _ => LightPrimaryFore
                        };
                        button.FlatAppearance.MouseDownBackColor = LightActiveButtonColor;
                        button.FlatAppearance.MouseOverBackColor = LightActiveButtonColor;
                    }
                    foreach (CheckBox checkBox in UserInterfaceLogic.GetAllControls<CheckBox>(form))
                    {
                        checkBox.ForeColor = LightPrimaryFore;
                    }
                    foreach (DataGridView dataGrid in UserInterfaceLogic.GetAllControls<DataGridView>(form))
                    {
                        dataGrid.BackgroundColor = LightPrimaryBack;
                        dataGrid.ForeColor = LightPrimaryFore;
                        dataGrid.BackColor = LightPrimaryBack;
                        dataGrid.ColumnHeadersDefaultCellStyle.ForeColor = LightPrimaryFore;
                        dataGrid.ColumnHeadersDefaultCellStyle.BackColor = LightPrimaryBack;
                        dataGrid.RowsDefaultCellStyle.ForeColor = LightSecondaryFore;
                        dataGrid.RowsDefaultCellStyle.BackColor = LightSecondaryBack;
                    }
                    break;
                case ApplicationTheme.Dark:
                    form.BackColor = DarkPrimaryBack;
                    foreach (Label label in UserInterfaceLogic.GetAllControls<Label>(form))
                    {
                        label.ForeColor = DarkPrimaryFore;
                    }
                    foreach (RadioButton radio in UserInterfaceLogic.GetAllControls<RadioButton>(form))
                    {
                        radio.ForeColor = DarkSecondaryFore;
                    }
                    foreach (TextBox textBox in UserInterfaceLogic.GetAllControls<TextBox>(form))
                    {
                        textBox.ForeColor = DarkSecondaryFore;
                        textBox.BackColor = DarkSecondaryBack;
                    }
                    foreach (Button button in UserInterfaceLogic.GetAllControls<Button>(form).Where(b => b.Tag?.ToString() != "UnchangeableColor"))
                    {
                        button.ForeColor = button.Tag?.ToString() switch
                        {
                            "ColorfulForeGreen" => DarkGreenFore,
                            "ColorfulForeRed" => DarkRedFore,
                            "ColorfulForePurple" => DarkPurpleFore,
                            "ColorfulForeBlue" => DarkBlueFore,
                            _ => DarkPrimaryFore
                        };
                        button.BackColor = DarkPrimaryBack;
                        button.FlatAppearance.BorderColor = button.Tag?.ToString() switch
                        {
                            "ColorfulForeGreen" => DarkGreenFore,
                            "ColorfulForeRed" => DarkRedFore,
                            "ColorfulForePurple" => DarkPurpleFore,
                            "ColorfulForeBlue" => DarkBlueFore,
                            _ => DarkPrimaryFore
                        };
                        button.FlatAppearance.MouseDownBackColor = DarkActiveButtonColor;
                        button.FlatAppearance.MouseOverBackColor = DarkActiveButtonColor;
                    }
                    foreach (CheckBox checkBox in UserInterfaceLogic.GetAllControls<CheckBox>(form))
                    {
                        checkBox.ForeColor = DarkPrimaryFore;
                    }
                    foreach (DataGridView dataGrid in UserInterfaceLogic.GetAllControls<DataGridView>(form))
                    {
                        dataGrid.BackgroundColor = DarkPrimaryBack;
                        dataGrid.ForeColor = DarkPrimaryFore;
                        dataGrid.BackColor = DarkPrimaryBack;
                        dataGrid.ColumnHeadersDefaultCellStyle.ForeColor = DarkPrimaryFore;
                        dataGrid.ColumnHeadersDefaultCellStyle.BackColor = DarkPrimaryBack;
                        dataGrid.RowsDefaultCellStyle.ForeColor = DarkSecondaryFore;
                        dataGrid.RowsDefaultCellStyle.BackColor = DarkSecondaryBack;
                    }
                    break;
            }
        }
    }
}
