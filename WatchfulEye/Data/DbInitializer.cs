using WatchfulEye.Models;

namespace WatchfulEye.Data
{
    public class DbInitializer
    {
        public static void Initialize(WatchfulEyeContext cx)
        {
            if(cx.emailTemplates.Any())
            {
                return;
            }

            var emails = new EmailTemplate[]
            {
                new EmailTemplate{difficultyLevel=0,name="test email",HTML="<h1>Hello</h1>",header="test email"}
            };

            cx.emailTemplates.AddRange(emails);
            cx.SaveChanges();
        }
    }
}
