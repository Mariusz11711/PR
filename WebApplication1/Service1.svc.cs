using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebApplication1.Models
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public void DoWork()
        {
        }
        public string AddText(string Title, string Lead, string Content, int CategoryId, List<int> Tags = null)
        {
            string ret = "Dodano tekst";

            try
            {
                Art temp = new Art();
                var context = new Model1();


                temp.Title = Title;
                temp.Lead = Lead;
                temp.Content = Content;
                temp.CategoryId = CategoryId;
                temp.Tags = Tags.ToString();
                temp.IsPublish = 0;
                context.Art.Add(temp);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                ret = "Ponów akcję: " + e;
            }

            return ret;
        }
        public string EditText(string Title = null, string Lead = null, string Content = null, int CategoryId = -1, List<int> Tags = null)
        {
            string ret = "Edytowano tekst";

            try
            {
                using (var db = new Model1())
                {
                    var temp = db.Art.SingleOrDefault(b => b.Title == Title && b.CategoryId == CategoryId);
                    if (temp != null)
                    {


                        if (Title != null) temp.Title = Title;
                        if (Lead != null) temp.Lead = Lead;
                        if (Content != null) temp.Content = Content;
                        if (CategoryId != -1) temp.CategoryId = CategoryId;
                        if (Tags != null) temp.Tags = Tags.ToString();
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                ret = "Ponów akcję: " + e;
            }

            return ret;
        }
        public string DeleteText(string Title, int CategoryId)
        {
            string ret = "Usunięto tekst";

            try
            {
                using (var db = new Model1())
                {
                    var result = db.Art.SingleOrDefault(b => b.Title == Title && b.CategoryId == CategoryId);
                    if (result != null)
                    {
                        db.Art.Remove(result);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                ret = "Ponów akcję: " + e;
            }

            return ret;
        }
        public string PublishText(string Title, int CategoryId)
        {
            string ret = "Wysłano tekst";

            try
            {
                using (var db = new Model1())
                {
                    var result = db.Art.SingleOrDefault(b => b.Title == Title && b.CategoryId == CategoryId);
                    if (result != null)
                    {
                        result.IsPublish = 1;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                ret = "Ponów akcję: " + e;
            }

            return ret;
        }
    }
}
