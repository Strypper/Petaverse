using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Markup;

namespace Petaverse.Helpers
{
    public class Grid
    {

        #region ColumnDefinitions Attached Property

        /// <summary> 
        /// Identifies the ColumnDefinitions attachted property. This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty ColumnDefinitionsProperty =
            DependencyProperty.RegisterAttached("ColumnDefinitions",
                                                typeof(string),
                                                typeof(Grid),
                                                new PropertyMetadata(default(string), OnColumnDefinitionsChanged));

        /// <summary>
        /// ColumnDefinitions changed handler. 
        /// </summary>
        /// <param name="d">Grid that changed its ColumnDefinitions attached property.</param>
        /// <param name="e">DependencyPropertyChangedEventArgs with the new and old value.</param> 
        private static void OnColumnDefinitionsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Windows.UI.Xaml.Controls.Grid source)
            {
                if (source.ColumnDefinitions?.Count == 0)
                {
                    var value = (string)e.NewValue;
                    var a = value.Split(',');
                    foreach (var text in a)
                    {
                        source.ColumnDefinitions.Add(new Windows.UI.Xaml.Controls.ColumnDefinition
                        {
                            Width = CreateGridLength(text),
                        });
                    }
                }
            }
        }

        /// <summary>
        /// Gets the value of the ColumnDefinitions attached property from the specified Windows.UI.Xaml.Controls.Grid.
        /// </summary>
        public static string GetColumnDefinitions(DependencyObject obj)
        {
            return (string)obj.GetValue(ColumnDefinitionsProperty);
        }


        /// <summary>
        /// Sets the value of the ColumnDefinitions attached property to the specified Windows.UI.Xaml.Controls.Grid.
        /// </summary>
        /// <param name="obj">The object on which to set the ColumnDefinitions attached property.</param>
        /// <param name="value">The property value to set.</param>
        public static void SetColumnDefinitions(DependencyObject obj, string value)
        {
            obj.SetValue(ColumnDefinitionsProperty, value);
        }

        #endregion ColumnDefinitions Attached Property

        #region RowDefinitions Attached Property

        /// <summary> 
        /// Identifies the RowDefinitions attachted property. This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty RowDefinitionsProperty =
            DependencyProperty.RegisterAttached("RowDefinitions",
                                                typeof(string),
                                                typeof(Grid),
                                                new PropertyMetadata(default(string), OnRowDefinitionsChanged));

        /// <summary>
        /// RowDefinitions changed handler. 
        /// </summary>
        /// <param name="d">Grid that changed its RowDefinitions attached property.</param>
        /// <param name="e">DependencyPropertyChangedEventArgs with the new and old value.</param> 
        private static void OnRowDefinitionsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Windows.UI.Xaml.Controls.Grid source)
            {
                if (source.RowDefinitions?.Count == 0)
                {
                    var value = (string)e.NewValue;
                    var a = value.Split(',');
                    foreach (var item in a)
                    {
                        source.RowDefinitions.Add(new Windows.UI.Xaml.Controls.RowDefinition
                        {
                            Height = CreateGridLength(item),
                        });
                    }
                }
            }
        }

        /// <summary>
        /// Gets the value of the RowDefinitions attached property from the specified Grid .
        /// </summary>
        public static string GetRowDefinitions(DependencyObject obj)
        {
            return (string)obj.GetValue(RowDefinitionsProperty);
        }

        /// <summary>
        /// Sets the value of the RowDefinitions attached property to the specified Grid .
        /// </summary>
        /// <param name="obj">The object on which to set the RowDefinitions attached property.</param>
        /// <param name="value">The property value to set.</param>
        public static void SetRowDefinitions(DependencyObject obj, string value)
        {
            obj.SetValue(RowDefinitionsProperty, value);
        }

        #endregion RowDefinitions Attached Property

        private static GridLength CreateGridLength(string text)
        {
            text = text.Trim();
            return text.Length == 0
                ? throw new XamlParseException("XAML parsing failed: Empty GridLength is not allowed")
                : text.EndsWith('*')
                ? new GridLength(text.Length > 1 ? double.Parse(text.Substring(0, text.Length - 1)) : 1, GridUnitType.Star)
                : text.Equals("auto", StringComparison.OrdinalIgnoreCase)
                    ? new GridLength(0D, GridUnitType.Auto)
                    : new GridLength(double.Parse(text), GridUnitType.Pixel);
        }

    }
}
