﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FlowModelDesktop
{
    /// <summary>
    /// Логика взаимодействия для ExperimentMainWindow.xaml
    /// </summary>
    public partial class ExperimentMainWindow : Window
    {
        public ExperimentMainWindow()
        {
            InitializeComponent();
        }

        private void ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            DeltaZ.Text = DeltaZ.Text.Replace(',', '.');
            H.Text = H.Text.Replace(',', '.');
            L.Text = L.Text.Replace(',', '.');
            W.Text = W.Text.Replace(',', '.');
            Min.Text = Min.Text.Replace(',', '.');
            Max.Text = Max.Text.Replace(',', '.');
            StepRange.Text = StepRange.Text.Replace(',', '.');
            Mode.Text = Mode.Text.Replace(',', '.');
        }

        private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            string TempOrVelocity = String.Empty;
            string Criteria = String.Empty;

            if (Temperature.IsChecked == true)
                TempOrVelocity = "T_u";
            if (Velocity.IsChecked == true)
                TempOrVelocity = "v_u";

            if (CheckBoxTemperatureCriteria.IsChecked == true)
                Criteria = "T";
            if (CheckBoxViscosityCriteria.IsChecked == true)
                Criteria = "\\eta";
            
            if ((bool)Temperature.IsChecked)
            {
                Range.Content = "≤ T ≤";
                ModeLabel.Content = "Скорость крышки, м/с";
            }

            if ((bool)Velocity.IsChecked)
            {
                Range.Content = "≤ v ≤";
                ModeLabel.Content = "Температура крышки, °C";
            }

            if ((bool)LinearModel.IsChecked)
            {
                CheckedModelFormula.Formula = $"a_1{TempOrVelocity} + a_0 = {Criteria}";
            }
            if ((bool)QuadModel.IsChecked)
            {
                CheckedModelFormula.Formula = $"a_2{TempOrVelocity}^2 + a_1{TempOrVelocity} + a_0 = {Criteria}";
            }
            if ((bool)CubeModel.IsChecked)
            {
                CheckedModelFormula.Formula = $"a_3{TempOrVelocity}^3 + a_2{TempOrVelocity}^2 + a_1{TempOrVelocity} + a_0 = {Criteria}";
            }
        }
    }
}
