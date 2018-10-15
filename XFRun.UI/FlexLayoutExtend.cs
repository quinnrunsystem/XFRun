using System;
using System.Collections;
using Xamarin.Forms;

namespace XFRun.UI.Forms
{
    public class FlexLayoutExtend : FlexLayout
    {
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
            nameof(ItemsSource),
            typeof(IEnumerable),
            typeof(FlexLayoutExtend),
            propertyChanged: OnItemsSourceChanged);

        static void OnItemsSourceChanged(BindableObject bindable, object oldVal, object newVal)
        {
            IEnumerable newValue = newVal as IEnumerable;
            var layout = (FlexLayoutExtend)bindable;

            layout.Children.Clear();
            if (newValue != null)
            {
                foreach (var item in newValue)
                {
                    layout.Children.Add(layout.CreateChildView(item));
                }
            }
        }

        View CreateChildView(object item)
        {
            ItemTemplate.SetValue(BindableObject.BindingContextProperty, item);
            return (View)ItemTemplate.CreateContent();
        }


        public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create(
                nameof(ItemTemplate),
                typeof(DataTemplate),
                typeof(FlexLayoutExtend));

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

    }
}

