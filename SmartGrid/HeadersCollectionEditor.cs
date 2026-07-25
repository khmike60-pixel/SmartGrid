using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing.Design;
using System.Windows.Forms;

namespace SmartGrid
{
    public class HeadersCollectionEditor : CollectionEditor
    {
        public HeadersCollectionEditor() : base(typeof(string[]))
        {
            //Debug.WriteLine("HeadersCollectionEditor ctor");
        }

        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            //Debug.WriteLine("HeadersCollectionEditor.EditValue entered");
            //Debugger.Launch(); // временно для отладки дизайнер-редактора

            var currentGrid = context?.Instance as SmartGrid;
            using (var form = new HeadersEditForm(currentGrid))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // возвращаем массив заголовков из формы
                    return form.Headers;
                }
            }

            return value;
        }
    }
}
