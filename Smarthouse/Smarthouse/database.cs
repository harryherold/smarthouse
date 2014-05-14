using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace Smarthouse
{
    class Feature
    {
        public Feature(int num, string n, string e, int v)
        {
            featurenum = num;
            name = n;
            enums = e;
            value = v;
        }
        public int featurenum { get; set; }
        public string name { get; set; }
        public string enums { get; set; }
        public int value { get; set; }
    }
    class ApplainceGroup
    {
        public int appgroupnum { get; set; }
        public string name { get; set; }
        public string command { get; set; }
        public string gesture { get; set; }
        public string proporties { get; set; }
    }
    class Applaince
    {
        public int appnum { get; set; }
        public string name { get; set; }
        public string command { get; set; }
        public string gestures { get; set; }
        public List<Feature> features { get; set; }
        public ApplainceGroup appgroup { get; set; }
    }
    class database
    {
        public List<Feature> getfeature(int paco)
        {
            string cs = "URI=file:C:\\temp\\smarthouse.db";
            List<Feature> feat1 = new List<Feature>();

            using (SQLiteConnection con = new SQLiteConnection(cs))
            {
                con.Open();

                String stm = "SELECT * FROM Feature where appnum= " + paco;

                using (SQLiteCommand cmd = new SQLiteCommand(stm, con))
                {

                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            //Feature tmp = new Feature();
                            int featurenum = rdr.GetInt32(0);
                            string names = rdr.GetString(1);
                            string enums = rdr.GetString(2);
                            int values = rdr.GetInt32(3);
                            feat1.Add(new Feature(featurenum, names, enums, values));
                            Console.WriteLine();
                        }
                    }
                }
                con.Close();
            }
            return feat1;
        }
        public int getLastId(string table, string primary)
        {
            int lastid = 0;
            string cs = "URI=file:C:\\temp\\smarthouse.db";
            using (SQLiteConnection con = new SQLiteConnection(cs))
            {
                con.Open();

                string stm = "select max("+primary +") from " + table;

                using (SQLiteCommand cmd = new SQLiteCommand(stm, con))
                {

                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        rdr.Read();
                        lastid = rdr.GetInt32(0);
                    }
                }
                con.Close();
            }
            return lastid;
        }
        public void AddFeatures(List<Feature> flist, int appnum)
        {
            string cs = "URI=file:C:\\temp\\smarthouse.db";

            using (SQLiteConnection con = new SQLiteConnection(cs))
            {
                try
                {
                    SQLiteCommand cmd = new SQLiteCommand(con);
                    con.Open();
                    foreach (Feature f in flist)
                    {
                        cmd.CommandText = "insert into Feature (name,value,enum,appnum) values (";
                        cmd.CommandText += "'" + f.name + "','" + f.value+ "','" + f.enums+ "','" + appnum+ "')";
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SQLiteException ex)
                {
                    // Display error
                    Console.WriteLine("Error: " + ex.ToString());
                }

                con.Close();
            }
        }
        public int AddAppliance(Applaince a)
        {
            string cs = "URI=file:C:\\temp\\smarthouse.db";

            using (SQLiteConnection con = new SQLiteConnection(cs))
            {
                try
                {
                    SQLiteCommand cmd = new SQLiteCommand(con);
                    con.Open();

                    cmd.CommandText = "insert into Appliance (name,commands,gestures,appgroup) values (";
                    cmd.CommandText += "'" + a.name + "','" + a.command + "','" + a.gestures + "','" + a.appgroup.appgroupnum + "')";
                    cmd.ExecuteNonQuery();
                }
                catch (SQLiteException ex)
                {
                    // Display error
                    Console.WriteLine("Error: " + ex.ToString());
                }

                con.Close();
            }
            return getLastId("Appliance","appnum");
        }
        public void setfeature( Feature f )
        {
            string cs = "URI=file:C:\\temp\\smarthouse.db";

            using (SQLiteConnection con = new SQLiteConnection(cs))
            {
                try
                {
                    SQLiteCommand cmd = new SQLiteCommand(con);
                    con.Open();

                    cmd.CommandText = "update feature set value='"+f.value+"' where featurenum='"+f.featurenum+"'";
                    cmd.ExecuteNonQuery();
                }
                catch (SQLiteException ex)
                {
                    // Display error
                    Console.WriteLine("Error: " + ex.ToString());
                }

                con.Close();
            }
        }
        public List<string> getAllApplainceNames()
        {
            int groupnum = 0;
            string cs = "URI=file:C:\\temp\\smarthouse.db";
            Applaince app1 = new Applaince();
            List<string> namelist = new List<string>();
            using (SQLiteConnection con = new SQLiteConnection(cs))
            {
                con.Open();

                string stm = "select name from appliance";

                using (SQLiteCommand cmd = new SQLiteCommand(stm, con))
                {

                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            namelist.Add(rdr.GetString(0));
                        }
                    }
                }
                con.Close();
            }
            return namelist;
        }
        public List<Applaince> getAllApps()
        {
            List<Applaince> allapps = new List<Applaince>();
            List<string> namelist = getAllApplainceNames();
            foreach (string appname in namelist)
            {
                allapps.Add(getApp(appname));
            }
            return allapps;
        }

        public Applaince getApp(string name)
        {
            int groupnum = 0;
            string cs = "URI=file:C:\\temp\\smarthouse.db";
            Applaince app1 = new Applaince();
            using (SQLiteConnection con = new SQLiteConnection(cs))
            {
                con.Open();

                string stm = "SELECT *  FROM Appliance where name = \""+name+"\"";

                using (SQLiteCommand cmd = new SQLiteCommand(stm, con))
                {

                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            app1.appnum = rdr.GetInt32(0);
                            app1.name = rdr.GetString(1);
                            app1.command = rdr.GetString(2);
                            app1.gestures = rdr.GetString(3);
                            groupnum = rdr.GetInt32(4);
                        }
                    }
                }
              

                stm = "SELECT * FROM Feature where appnum= "+app1.appnum;
                app1.features = new List<Feature>();
                using (SQLiteCommand cmd = new SQLiteCommand(stm, con))
                {

                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            //Feature tmp = new Feature();
                            int values = rdr.GetInt32(0);
                            int featurenum = rdr.GetInt32(1);
                            string names = rdr.GetString(2);
                            string enums = rdr.GetString(3);
                            
                            app1.features.Add(new Feature(featurenum,names,enums,values) );
                            Console.WriteLine();
                        }
                    }
                }
                con.Close();
            }
            return app1;
        }

    }
}
