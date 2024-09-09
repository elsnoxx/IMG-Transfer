using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;

namespace Transfer_IMG.ContexMenu
{
    public partial class Dochazka : UserControl
    {
        private TableLayoutPanel tableLayoutPanel;
        private Button btnPrepocitat; // Přidáme tlačítko

        public Dochazka()
        {
            InitializeComponent();
            VytvorDochazku(DateTime.Now.Year, DateTime.Now.Month); // Nastaví aktuální měsíc
        }

        // Vytvoření layoutu pro docházku
        private void VytvorDochazku(int year, int month)
        {
            // Získání počtu dnů v daném měsíci
            int daysInMonth = DateTime.DaysInMonth(year, month);

            // Inicializace TableLayoutPanel
            tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.ColumnCount = 4; // 4 sloupce: Den, Příchod, Odchod, Saldo
            tableLayoutPanel.RowCount = daysInMonth;
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.AutoSize = true;
            tableLayoutPanel.AutoScroll = true;
            tableLayoutPanel.BorderStyle = BorderStyle.FixedSingle;

            // Přidání TableLayoutPanel na formulář
            this.Controls.Add(tableLayoutPanel);


            // Pro každý den v měsíci
            for (int day = 1; day <= daysInMonth; day++)
            {
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30)); // Výška každého řádku
                DateTime currentDay = new DateTime(year, month, day);

                // Vytvoření Label pro zobrazení data
                Label labelDay = new Label();
                labelDay.Text = currentDay.ToString("dd.MM.yyyy");
                labelDay.Anchor = AnchorStyles.Left;
                labelDay.Font = new Font("Arial", 10, FontStyle.Bold);
                labelDay.AutoSize = true;

                // Vytvoření DateTimePicker pro zadání příchodu, nastaveno na 6:30
                DateTimePicker dtpPrichod = new DateTimePicker();
                dtpPrichod.Name = $"dtpPrichod{day}";
                dtpPrichod.Format = DateTimePickerFormat.Time;
                dtpPrichod.ShowUpDown = true;
                dtpPrichod.CustomFormat = "HH:mm";
                dtpPrichod.Value = new DateTime(currentDay.Year, currentDay.Month, currentDay.Day, 6, 10, 0); // Nastavíme příchod na 6:30
                dtpPrichod.Width = 80;

                // Vytvoření DateTimePicker pro zadání odchodu
                DateTimePicker dtpOdchod = new DateTimePicker();
                dtpOdchod.Name = $"dtpOdchod{day}";
                dtpOdchod.Format = DateTimePickerFormat.Custom;
                dtpOdchod.CustomFormat = "HH:mm";
                dtpOdchod.ShowUpDown = true;
                dtpOdchod.Value = DateTime.Today; // Použijeme dnešní datum jako placeholder, protože nemůžeme použít null
                dtpOdchod.Width = 80;

                // Přidání event handleru pro přepočet salda při změně odchodu
                dtpOdchod.ValueChanged += (sender, e) => PrepocitejSaldo(day);

                // Vytvoření Label pro zobrazení salda
                Label labelSaldo = new Label();
                labelSaldo.Name = $"labelSaldo{day}";
                labelSaldo.Width = 80;
                labelSaldo.Font = new Font("Arial", 10);
                labelSaldo.Margin = new Padding(5);
                labelSaldo.Text = "00:00";

                // Zkontroluje, zda je to sobota nebo neděle
                if (currentDay.DayOfWeek == DayOfWeek.Saturday || currentDay.DayOfWeek == DayOfWeek.Sunday)
                {
                    labelDay.BackColor = Color.LightGray;
                    dtpOdchod.Visible = false;
                    dtpPrichod.Visible = false;
                    labelSaldo.Visible = false;
                }

                // Přidání komponent do TableLayoutPanel
                tableLayoutPanel.Controls.Add(labelDay, 0, day - 1);    // Sloupec 0
                tableLayoutPanel.Controls.Add(dtpPrichod, 1, day - 1);  // Sloupec 1
                tableLayoutPanel.Controls.Add(dtpOdchod, 2, day - 1);   // Sloupec 2
                tableLayoutPanel.Controls.Add(labelSaldo, 3, day - 1);  // Sloupec 3
            }
        }


        // Metoda pro přepočet salda
        private TimeSpan PrepocitejSaldo(int day)
        {
            // Získání DateTimePicker pro příchod a odchod
            DateTimePicker dtpPrichod = tableLayoutPanel.Controls[$"dtpPrichod{day}"] as DateTimePicker;
            DateTimePicker dtpOdchod = tableLayoutPanel.Controls[$"dtpOdchod{day}"] as DateTimePicker;

            // Kontrola, zda ovládací prvky nejsou null
            if (dtpPrichod == null || dtpOdchod == null)
            {
                // Pokud některý z ovládacích prvků není nalezen, vrátíme TimeSpan.Zero
                return TimeSpan.Zero;
            }

            // Pokud je hodnota odchodu "nevyplněná", nastavíme ji na minimální čas
            if (dtpOdchod.Value.TimeOfDay == DateTime.MinValue.TimeOfDay)
            {
                return TimeSpan.Zero;
            }

            // Výpočet rozdílu (saldo) - čas strávený v práci
            TimeSpan saldo = dtpOdchod.Value.TimeOfDay - dtpPrichod.Value.TimeOfDay;

            // Odečtení půlhodinové pauzy, pokud je pracovní doba delší než 6 hodin
            if (saldo.TotalHours > 6)
            {
                saldo = saldo - TimeSpan.FromMinutes(30);
            }

            // Aktualizace labelu se saldem
            Label labelSaldo = tableLayoutPanel.Controls[$"labelSaldo{day}"] as Label;
            if (labelSaldo != null)
            {
                labelSaldo.Text = saldo.ToString(@"hh\:mm");
            }

            // Vrátíme saldo jako TimeSpan pro další výpočet
            return saldo;
        }



        // Metoda pro zpracování zadaných údajů
        public List<AttendanceRecord> ZpracujDochazku()
        {
            List<AttendanceRecord> attendanceRecords = new List<AttendanceRecord>();

            // Počet dnů v měsíci
            int daysInMonth = tableLayoutPanel.RowCount;

            for (int day = 1; day <= daysInMonth; day++)
            {
                // Vyber DateTimePicker pro příchod a odchod podle názvu
                DateTimePicker dtpPrichod = (DateTimePicker)tableLayoutPanel.Controls[$"dtpPrichod{day}"];
                DateTimePicker dtpOdchod = (DateTimePicker)tableLayoutPanel.Controls[$"dtpOdchod{day}"];

                // Získání hodnot příchodu a odchodu z DateTimePicker
                DateTime prichod = dtpPrichod.Value;
                DateTime odchod = dtpOdchod.Value;

                // Výpočet rozdílu (saldo) - čas strávený v práci
                TimeSpan saldo = odchod - prichod;

                // Přidání záznamu do seznamu
                attendanceRecords.Add(new AttendanceRecord
                {
                    Day = new DateTime(DateTime.Now.Year, DateTime.Now.Month, day),  // Příslušný den
                    Arrival = prichod.ToString("HH:mm"),  // Příchod ve formátu HH:mm
                    Departure = odchod.ToString("HH:mm"),  // Odchod ve formátu HH:mm
                    WorkedHours = saldo.ToString(@"hh\:mm"), // Strávený čas (např. 8:30 hodin)
                });
            }

            return attendanceRecords;
        }

        private void Prepocitat_Click(object sender, EventArgs e)
        {
            TimeSpan celkemOdpracovano = new TimeSpan();
            int cntPracovnichDnu = 0;

            // Pro každý den v měsíci
            for (int day = 1; day <= tableLayoutPanel.RowCount; day++)
            {
                // Získání rozdílu mezi příchodem a odchodem
                TimeSpan saldo = PrepocitejSaldo(day);

                // Pokud je den pracovní (tj. není víkend), přičti saldo a zvyš počet pracovních dnů
                DateTime currentDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, day);
                if (currentDay.DayOfWeek != DayOfWeek.Saturday && currentDay.DayOfWeek != DayOfWeek.Sunday)
                {
                    celkemOdpracovano += saldo;
                    cntPracovnichDnu++;
                }
            }

            // Očekávaný čas (např. 8 hodin denně)
            TimeSpan ocekavanyCas = TimeSpan.FromHours(8 * cntPracovnichDnu); // 8 hodin * počet pracovních dnů

            // Výpočet rozdílu mezi skutečným časem a očekávaným
            TimeSpan rozdil = celkemOdpracovano - ocekavanyCas;

            // Zobraz výsledek v labelu (zda jsi v plusu nebo v minusu)
            string textRozdilu = rozdil.TotalHours >= 0
                ? $"Jsi v plusu: {rozdil.TotalHours:F2} hodin"
                : $"Jsi v minusu: {-rozdil.TotalHours:F2} hodin";

            celkemHodin.Text = textRozdilu;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Vytvoření nového Excelového souboru
            using (var workbook = new XLWorkbook())
            {
                // Přidání nového listu do souboru
                var worksheet = workbook.Worksheets.Add("Docházka");

                // Nastavení hlaviček
                worksheet.Cell(1, 1).Value = "Den";
                worksheet.Cell(1, 2).Value = "Příchod";
                worksheet.Cell(1, 3).Value = "Odchod";
                worksheet.Cell(1, 4).Value = "Saldo";

                // Příprava stylu pro hlavičky
                var headerStyle = worksheet.Range("A1:D1").Style;
                headerStyle.Font.Bold = true;
                headerStyle.Fill.BackgroundColor = XLColor.LightGray;

                // Vyplnění dat z TableLayoutPanel
                int rowIndex = 2;
                for (int day = 1; day <= tableLayoutPanel.RowCount; day++)
                {
                    // Získání příchodu, odchodu a salda
                    var dtpPrichod = tableLayoutPanel.Controls[$"dtpPrichod{day}"] as DateTimePicker;
                    var dtpOdchod = tableLayoutPanel.Controls[$"dtpOdchod{day}"] as DateTimePicker;
                    var labelSaldo = tableLayoutPanel.Controls[$"labelSaldo{day}"] as Label;

                    // Kontrola, zda jsou ovládací prvky správného typu
                    if (dtpPrichod != null && dtpOdchod != null && labelSaldo != null)
                    {
                        worksheet.Cell(rowIndex, 1).Value = $"{day:D2}.{DateTime.Now.Month:D2}.{DateTime.Now.Year}"; // Den (DD.MM.RRRR)
                        worksheet.Cell(rowIndex, 2).Value = dtpPrichod.Value.ToString("HH:mm"); // Příchod (HH:mm)
                        worksheet.Cell(rowIndex, 3).Value = dtpOdchod.Value.ToString("HH:mm"); // Odchod (HH:mm)
                        worksheet.Cell(rowIndex, 4).Value = labelSaldo.Text; // Saldo (HH:mm)
                        
                        if (!dtpPrichod.Visible)
                        {
                            worksheet.Cell(rowIndex, 1).Style.Fill.BackgroundColor = XLColor.Gray;
                            worksheet.Cell(rowIndex, 2).Style.Fill.BackgroundColor = XLColor.Gray;
                            worksheet.Cell(rowIndex, 3).Style.Fill.BackgroundColor = XLColor.Gray;
                            worksheet.Cell(rowIndex, 4).Style.Fill.BackgroundColor = XLColor.Gray;
                        }
                        // Nastavení barvy pozadí řádku na základě salda
                        //TimeSpan saldo;
                        //if (TimeSpan.TryParse(labelSaldo.Text, out saldo))
                        //{
                        //    if (saldo.TotalMinutes > 510) // 8:30 hodiny = 510 minut
                        //    {
                        //        worksheet.Row(rowIndex).Style.Fill.BackgroundColor = XLColor.Green;
                        //    }
                        //    else
                        //    {
                        //        worksheet.Row(rowIndex).Style.Fill.BackgroundColor = XLColor.Red;
                        //    }
                        //}

                        rowIndex++;
                    }
                }

                // Nastavení výchozího názvu souboru
                string datum = DateTime.Now.ToString("MMMM");
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx",
                    Title = "Uložit docházku do Excelu",
                    FileName = $"Docházka_{datum}.xlsx" // Nastaví výchozí název souboru
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveFileDialog.FileName);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Vyberte soubor Excel
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Vyberte soubor s docházkou"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Načítání souboru
                using (var workbook = new XLWorkbook(openFileDialog.FileName))
                {
                    var worksheet = workbook.Worksheet("Docházka"); // Název listu

                    // Čtení dat z Excelu
                    int rowIndex = 2;
                    while (worksheet.Cell(rowIndex, 1).Value.ToString() != "")
                    {
                        string dateStr = worksheet.Cell(rowIndex, 1).Value.ToString();
                        string arrival = worksheet.Cell(rowIndex, 2).Value.ToString();
                        string departure = worksheet.Cell(rowIndex, 3).Value.ToString();
                        string balance = worksheet.Cell(rowIndex, 4).Value.ToString();

                        // Vyhledání ovládacích prvků v TableLayoutPanel
                        var dtpPrichod = tableLayoutPanel.Controls[$"dtpPrichod{rowIndex - 1}"] as DateTimePicker;
                        var dtpOdchod = tableLayoutPanel.Controls[$"dtpOdchod{rowIndex - 1}"] as DateTimePicker;
                        var labelSaldo = tableLayoutPanel.Controls[$"labelSaldo{rowIndex - 1}"] as Label;

                        if (dtpPrichod != null && dtpOdchod != null && labelSaldo != null)
                        {
                            // Nastavení hodnot
                            dtpPrichod.Value = DateTime.ParseExact(arrival, "HH:mm", null);
                            dtpOdchod.Value = DateTime.ParseExact(departure, "HH:mm", null);
                            labelSaldo.Text = balance;

                            // Nastavení barvy pozadí řádku podle hodnoty
                            if (DateTime.TryParseExact(arrival, "HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime arrivalTime) &&
                                DateTime.TryParseExact(departure, "HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime departureTime))
                            {
                                TimeSpan saldo = departureTime.TimeOfDay - arrivalTime.TimeOfDay;
                            }
                        }

                        rowIndex++;
                    }
                }
            }
        }
    }

    // Třída pro uložení docházkového záznamu
    public class AttendanceRecord
    {
        public DateTime Day { get; set; }
        public string Arrival { get; set; }
        public string Departure { get; set; }
        public string WorkedHours { get; set; }
    }
}
