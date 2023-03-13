using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Group
    {
        public int Id { get; set; }
        public string Special { get; set; }
        public int ClassRoom { get; set; }
        public int SubGroup { get; set; }
        public int StartYear { get; set; }

        public static void CreateGroups()
        {
            List<string> list = new List<string>();
            list.Add("П");
            list.Add("Б");
            list.Add("Э");
            list.Add("С");
            list.Add("А");
            list.Add("Г");
            using (var db = new DBContext())
            {
                foreach (string s in list)
                {
                    Special special = new Special { Code = s, Name = "Программисты" };
                    db.Specials.Add(special);
                    for (int y = 0; y < 4; y++)
                    {
                        for (int sg = 0; sg < 2; sg++)
                        {
                            Group group = new Group
                            {
                                ClassRoom = 9,
                                SubGroup = sg + 1,
                                StartYear = 2019 + y,
                                Special = special.Code
                            };
                            db.Groups.Add(group);
                        }
                    }
                    db.SaveChanges();
                }
            }
        }
        public string GetCode()
        {
            int kourse = DateTime.Now.Year - StartYear;
            if (DateTime.Now.Month >= 9) kourse++;
            
            return $"{kourse}-{SubGroup}{Special}{ClassRoom}";
        }
    }
}
