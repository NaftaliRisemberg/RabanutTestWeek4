using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace RabanutTestWeek4
{
    public partial class Form1 : Form
    {
        // יצירת משתנה שיקבל את הנתיב למסמך
        XmlDocument xmlDocument;

        // יצירת נתיב לקובץ מה שהופך את המשתנה שלמעלה לקובץ
        string pathName = Directory.GetCurrentDirectory() + "\\Dates.xml";
        public Form1()
        {
            InitializeComponent();

            xmlDocument = new XmlDocument();
            if (File.Exists(pathName))
            {
                try
                {
                    xmlDocument.Load(pathName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading file" + ex);

                }

            }
            else
            {
                XmlNode root = xmlDocument.CreateElement("Queries");

                xmlDocument.AppendChild(root);
                xmlDocument.Save(pathName);
            }
        }

        private bool CheckEmptyComboBox(Form form)
        {
            foreach (Control ctr in form.Controls)
            {
                if (ctr is ComboBox)
                {
                    if (string.IsNullOrWhiteSpace(ctr.Text))
                    {
                        MessageBox.Show("נא למלא את כל השדות");
                        return true;
                    }
                }

            }
            return false;
        }

        private void btnCreateDate_Click(object sender, EventArgs e)
        {
            if (CheckEmptyComboBox(this))
            {
                return;
            }

            else
            {
                XmlNode Query = xmlDocument.CreateElement("Query");

                Query.AppendChild(xmlDocument.CreateElement("day")).InnerText = cmbDay.Text;
                Query.AppendChild(xmlDocument.CreateElement("DayMonth")).InnerText = cmbMonthDay.Text;
                Query.AppendChild(xmlDocument.CreateElement("Month")).InnerText = cmbMonth.Text;
                Query.AppendChild(xmlDocument.CreateElement("Year")).InnerText = cmbYear.Text;
                // קריאה לפונקציה שתמלא את התוצאה בערך לפי הערכים שלמעלה 
                Query.AppendChild(xmlDocument.CreateElement("Result")).InnerText = ConvertToDateString();


                xmlDocument.FirstChild.AppendChild(Query);
                xmlDocument.Save(pathName);

                // קריאה לפונקציה שתראה את התאריך הנכנס למטה
                ShowCurrentDate();
                MessageBox.Show("נוסף בהצלחה");
            }


        }

        private void ShowCurrentDate()
        {
            txtCurrentDate.Text = ConvertToDateString();
            return;
        }
        
        private string ConvertToDateString()
        {
            string result = GetDay() + " " + GetDayMonth() + " " + GetMonth() + " " + GetYear();
            return result; 
        }

        private string GetDay()
        {
            switch(cmbDay.Text)
            {
                case "ראשון":
                    return "באחד בשבת";
                case "שני":
                    return "בשני בשבת";
                case "שלישי":
                    return "בשלישי בשבת";
                case "רביעי":
                    return "ברביעי בשבת";
                case "חמישי":
                    return "בחמישי בשבת";
                case "שישי":
                    return "בשישי בשבת";
            }
            return "rr";
        }

        private string GetDayMonth()
        {
            switch (cmbMonthDay.Text)
            {
                case "א":
                    return "יום אחד";
                case "ב":
                    return "שני ימים";
                case "ג":
                    return "שלושה ימים";
                case "ד":
                    return "ארבעה ימים";
                case "ה":
                    return "חמישה ימים";
                case "ו":
                    return "שישה ימים";
                case "ז":
                    return "שבעה ימים";
                case "ח":
                    return "שמונה ימים";
                case "ט":
                    return "תשעה ימים";
                case "י":
                    return "עשרה ימים";
                case "יא":
                    return "אחד עשר יום";
                case "יב":
                    return "שנים עשר יום";
                case "יג":
                    return "שלושה עשר יום";
                case "יד":
                    return "ארבעה עשר יום";
                case "טו":
                    return "חמשה עשר יום";
                case "טז":
                    return "שישה עשר יום";

                case "יז":
                    return "שבעה עשר יום";
                case "יח":
                    return "שמונה עשר יום";
                case "יט":
                    return "תשעה עשר יום";
                case "כ":
                    return "עשרים יום";
                case "כא":
                    return "אחד ועשרים יום";
                case "כב":
                    return "שנים ועשרים יום";
                case "כג":
                    return "שלושה ועשרים יום";
                case "כד":
                    return "ארבעה ועשרים יום";
                case "כה":
                    return "חמישה ועשרים יום";
                case "כו":
                    return "שישה ועשרים יום";
                case "כז":
                    return "שבעה ועשרים יום";
                case "כח":
                    return "שמונה ועשרים יום";
                case "כט":
                    return "תשעה ועשרים יום";
                case "ל":
                    return "ראש החודש";
            }
            return cmbDay.Text;
        }

        private string GetMonth()
        {
            switch (cmbMonth.Text)
            {
                case "תשרי":
                    return "לירח תשרי";
                case "חשון":
                    return "לירח מרחשון";
                case "כסליו":
                    return "לירח כסליו";
                case "טבת":
                    return "לירח טבת";
                case "שבט":
                    return "לירח שבט";
                case "אדר א":
                    return "לירח אדר א";
                case "אדר ב":
                    return "לירח אדר ב";
                case "ניסן":
                    return "לירח ניסן";
                case "אייר":
                    return "לירח אייר";
                case "סיוון":
                    return "לירח סיוון";
                case "תמוז":
                    return "לירח תמוז";
                case "אב":
                    return "לירח אב";
                case "אלול":
                    return "לירח אלול";

            }
            return cmbDay.Text;
        }


        private string GetYear()
        {
            switch (cmbYear.Text)
            {
                case "תשפד":
                    return "שנת חמשת אלפים ושבע מאות ושמנים וארבע לבריאת העולם";
                case "תשפה":
                    return "שנת חמשת אלפים ושבע מאות ושמנים וחמש לבריאת העולם";
                case "תשפו":
                    return "שנת חמשת אלפים ושבע מאות ושמנים ושש לבריאת העולם";
                case "תשפז":
                    return "שנת חמשת אלפים ושבע מאות ושמנים ושבע לבריאת העולם";
                case "תשפח":
                    return "שנת חמשת אלפים ושבע מאות ושמנים ושמונה לבריאת העולם";
                case "תשפט":
                    return "שנת חמשת אלפים ושבע מאות ושמנים ותשע לבריאת העולם";
                case "תשצ":
                    return "שנת חמשת אלפים ושבע מאות ותשעים לבריאת העולם";
            }
            return cmbDay.Text;
        }
    
    }
}

        



