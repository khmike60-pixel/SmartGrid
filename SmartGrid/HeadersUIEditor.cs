using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace SmartGrid
{
    public class HeadersUIEditor : UITypeEditor
    {
        private IWindowsFormsEditorService edSvc = null;

        public HeadersUIEditor()
        {
            Debug.WriteLine("HeadersUIEditor ctor");
        }

        // Стиль редактора — модальный диалог
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (context != null && context.Instance != null && provider != null)
            {
                // Получаем интерфейс сервиса
                edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

                if (edSvc != null)
                {
                    // Текущий редактируемый компонент
                    SmartGrid currentGrid = context.Instance as SmartGrid;

                    // Создаем форму для редактирования
                    using (HeadersEditForm form = new HeadersEditForm(currentGrid))
                    {
                        // Вызываем модальный диалог
                        if (edSvc.ShowDialog(form) == DialogResult.OK)
                        {
                            // Получаем новое значение
                            value = form.Headers;
                        }
                    }
                }
            }
            // Возвращаем либо старое, либо новое значение
            return value;
        }
    }
}
