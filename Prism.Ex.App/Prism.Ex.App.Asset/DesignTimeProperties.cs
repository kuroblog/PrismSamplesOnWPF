
//namespace Prism.Ex.App.Asset
//{
//    using System.ComponentModel;
//    using System.Windows;
//    using System.Windows.Controls;
//    using System.Windows.Media;

//    public class DesignTimeProperties : DependencyObject
//    {
//        public Brush DesignBackground
//        {
//            get => (Brush)GetValue(MyPropertyProperty);
//            set => SetValue(MyPropertyProperty, value);
//        }

//        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
//        public static readonly DependencyProperty MyPropertyProperty =
//            DependencyProperty.Register(nameof(DesignBackground), typeof(Brush), typeof(DesignTimeProperties), new PropertyMetadata(Brushes.Transparent, DesignBackgroundChangedCallback));

//        public static void DesignBackgroundChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
//        {
//            if (IsInDesignMode)
//            {
//                var control = d as Control;
//                var brush = e.NewValue as Brush;
//                if (control != null && brush != null)
//                {
//                    control.Background = brush;
//                }
//            }
//        }

//        public static bool IsInDesignMode => (bool)DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue;
//    }
//}
