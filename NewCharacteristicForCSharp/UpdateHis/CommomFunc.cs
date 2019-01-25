using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateHis
{
    public class CommomFunc
    {
        /// <summary>
        /// 把config的文件copy到childconfig
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public static void FindSameType(string ip, string username, string password)
        {
            var path = System.IO.Directory.GetCurrentDirectory();
            var runpath = path + @"\Config";
            DirectoryInfo dir = new DirectoryInfo(runpath);
            //path为某个目录，如： “D:\Program Files”
            FileInfo[] inf = dir.GetFiles();
            foreach (FileInfo finf in inf)
            {
                if (finf.Extension.Equals(".config"))
                {
                    string wenpath = runpath + @"\" + finf.Name;

                    File.Copy(wenpath, runpath + @"\ChildConfig\" + finf.Name, true);

                    string con = "";
                    //FileStream fs = new FileStream(runpath + @"\ChildConfig\" + finf.Name, FileMode.Open, FileAccess.ReadWrite);
                    //StreamReader sr = new StreamReader(fs);
                    //con = sr.ReadToEnd();
                    con = File.ReadAllText(runpath + @"\ChildConfig\" + finf.Name);
                  
                    con = con.Replace("hissql.ip", ip);
                    con = con.Replace("hissql.username", username);
                    con = con.Replace("hissql.password", password);
                    //sr.Close();
                    //fs.Close();
                    File.WriteAllText(runpath + @"\ChildConfig\" + finf.Name, con);
                    //FileStream fs2 = new FileStream(runpath + @"\ChildConfig\" + finf.Name, FileMode.Open, FileAccess.ReadWrite);
                    //StreamWriter sw = new StreamWriter(fs2);
                    //sw.WriteLine(con);
                    //sw.Close();
                    //fs2.Close();

                    File.Copy(runpath + @"\ChildConfig\" + finf.Name, path + @"\" + finf.Name, true);
                }


                //读取文件的完整目录和文件名
            }
        }
    }
}
