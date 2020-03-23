using P12_NossoChat.Model;
using Xamarin.Forms;

namespace P12_NossoChat.Utils
{
    public class MensagemDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate UserMsgTemplate { get; set; }
        public DataTemplate OthersMsgTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is Mensagem m && m.id_usuario == UserUtils.UserLogged.id) {
                return UserMsgTemplate;
            }
            else return OthersMsgTemplate;
        }
    }
}