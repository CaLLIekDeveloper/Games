using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackpackTask
{
    public partial class Form1 : Form
    {
        private List<Item> items = new List<Item>();

        DataGridViewTextBoxCell temp;

        int countItemsAll;

        public Form1()
        {
            InitializeComponent();

            //table.AutoGenerateColumns = true;
            tableOnce.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tableOnce.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            tableOnce.BorderStyle = BorderStyle.None;
            tableOnce.RowHeadersWidth = 30;

            //AddItems();
            //ShowItems(items);

            createDirectory();
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory + "\\files";
            saveFileDialog1.InitialDirectory = Environment.CurrentDirectory + "\\files";
        }

        private void createDirectory()
        {
            string path = Environment.CurrentDirectory + "\\files";

            try
            {
                if (Directory.Exists(path))
                {
                    return;
                }
                DirectoryInfo di = Directory.CreateDirectory(path);

            }
            catch (Exception e)
            {
            }
        }


        private void setItems()
        {
            try
            {
                items.Clear();

                for (int j = 0; j < tableOnce.RowCount; j++)
                {
                    temp = (DataGridViewTextBoxCell)tableOnce.Rows[j].Cells[0];
                    string NAME = temp.Value.ToString();
                    temp = (DataGridViewTextBoxCell)tableOnce.Rows[j].Cells[1];
                    int WEIGHT = int.Parse(temp.Value.ToString());
                    temp = (DataGridViewTextBoxCell)tableOnce.Rows[j].Cells[2];
                    int PRICE = int.Parse(temp.Value.ToString());
                    items.Add(new Item(NAME, WEIGHT, PRICE));
                }
            }catch(Exception ex)
            {
                _Message.Show(this, "Невірні данні в таблиці", "Помилка");
            }
        }



        private void fillTable()
        {

        }


        private bool isFillTable()
        {
            try
            {
                for (int i = 0; i < tableOnce.RowCount; i++)
                    for (int j = 0; j < tableOnce.ColumnCount; j++)
                    {
                        temp = (DataGridViewTextBoxCell)tableOnce.Rows[i].Cells[j];
                        if (temp.Value.ToString().Equals("")) return false;
                    }
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }

        private void AddItems()
        {
            items = new List<Item>();
            items.Add(new Item("Книга", 1, 600));
            items.Add(new Item("Бинокль", 2, 5000));
            items.Add(new Item("Аптечка", 4, 1500));
            items.Add(new Item("Ноутбук", 2, 40000));
            items.Add(new Item("Котелок", 1, 500));

            tableOnce.RowCount = 5;
            for (int j = 0; j < tableOnce.RowCount; j++)
            {
                temp = (DataGridViewTextBoxCell)tableOnce.Rows[j].Cells[0];
                temp.Value = items[j].name;
                temp = (DataGridViewTextBoxCell)tableOnce.Rows[j].Cells[1];
                temp.Value = items[j].weigth;
                temp = (DataGridViewTextBoxCell)tableOnce.Rows[j].Cells[2];
                temp.Value = items[j].price;
            }
        }

        private void getRandomItems()
        {

        }


        private void ShowItems(List<Item> _items)
        {
            listOnce.Visible = true;
            listOnce.Items.Clear();

            foreach (Item i in _items)
            {
                listOnce.Items.Add(new ListViewItem(new string[] { i.name, i.weigth.ToString(), 
                    i.price.ToString() }));
            }
        }


        //показать исходные данные
        private void ShowConditionsButton_Click(object sender, EventArgs e)
        {
            ShowItems(items);
            listOnce.Visible = false;
            tableOnce.Visible = true;

        }

        private int getBestWeight(List<Item> temp)
        {
            int weight = 0;
            for (int i = 0; i < temp.Count; i++)
            {
                weight += temp[i].weigth;
            }
            return weight;
        }

        private int getBestPrice(List<Item> temp)
        {
            int price = 0;
            for (int i = 0; i < temp.Count; i++)
            {
                price += temp[i].price;
            }
            return price;
        }


        //решить задачу
        private void solveButton_Click(object sender, EventArgs e)
        {
            int maxCountItems = 0;
            int _countItems = 0;

            bool flag = false;
            try
            {
                maxCountItems = int.Parse(weightTextBox.Text);
                _countItems = int.Parse(countItems.Text);
                flag = true;
            }
            catch(Exception ex)
            {
                _Message.Show(this, "Невірні данні", "Помилка");
                flag = false;
            }

            if (flag && _countItems == 0)
            {
                flag = false;
                _Message.Show(this, "Кількість предметів повинна бути більше нуля", "Помилка");
            }


            if (flag)
            try
            {
                    if (isFillTable())
                    {
                        setItems();
                        Stopwatch stopWatch = new Stopwatch();
                        stopWatch.Start();

                        Backpack bp = new Backpack(maxCountItems);
                        int resultOnce = bp.dynamicProggraming(items);
                        List<Item> solveOnce = bp.listOnce;

                        stopWatch.Stop();
                        // Get the elapsed time as a TimeSpan value.
                        TimeSpan ts = stopWatch.Elapsed;
                        // Format and display the TimeSpan value.
                        string elapsedTime = String.Format("{0:00}:{1:00}.{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds);
                        if (ts.Minutes == 0 && ts.Seconds == 0 && ts.Milliseconds == 0)
                            elapsedTime = "Тиков " + ts.Ticks;
                        Console.WriteLine("RunTime " + elapsedTime);
                        Console.WriteLine("Ticks " + ts.Ticks);

                        if (solveOnce.Count == 0 )
                        {
                            answerOnce.Text = "Рішення немає";
                            listOnce.Visible = false;
                        }
                        else
                        {
                            tableOnce.Visible = false;
                            listOnce.Visible = true;
                            listOnce.Items.Clear();
                            ShowItems(solveOnce);

                            answerOnce.Text = "Кількість предметів " + solveOnce.Count+" на вагу "+ bp.bestWeightOnce + " і сумму " + resultOnce;  
                        }
                        lTime.Text = "Час на виконання динамічного програмування: " + elapsedTime;

                    }
                    else
                     _Message.Show(this, "Заповніть таблицю", "Помилка");
                }
                catch(Exception ex)
            {
                _Message.Show(this,"Невірні данні в таблиці","Помилка");
            }
        }

        private void countItems_TextChanged(object sender, EventArgs e)
        {
            listOnce.Visible = false;
            tableOnce.Visible = true;
            try
            {
                if(countItems.Text.Length>0)
                {
                    countItemsAll = int.Parse(countItems.Text);
                    tableOnce.RowCount = countItemsAll;

                }
            }
            catch(Exception ex)
            {
                _Message.Show(this, "Кількість речей повинно бути цілим числом", "Помилка");
            }
        }

        private void завантажитиНабірДаннихToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                openFileDialog1.Filter = "Файли txt|*.txt|Файли cs|*.cs";
                System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName);
                string s = "";
                try
                {
                    weightTextBox.Text = sr.ReadLine();
                    countItemsAll= int.Parse(sr.ReadLine());
                    countItems.Text = countItemsAll.ToString();
                    tableOnce.RowCount = countItemsAll;

                    for (int i = 0; i < tableOnce.RowCount; i++)
                    {
                        string line = sr.ReadLine();
                        String[] words = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        for (int j = 0; j < tableOnce.ColumnCount; j++)
                        {
                            DataGridViewTextBoxCell txtxCell = (DataGridViewTextBoxCell)tableOnce.Rows[i].Cells[j];
                            txtxCell.Value = words[j];
                        }
                    }
                }
                catch (Exception ex)
                {
                    _Message.Show(this, "Невірний формат", "Помилка");
                }
            }
        }

        private void зберегтиНабірДаннихToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int countTemp = 0;
            int maxTemp = 0;
            bool flag = false;

            try
            {
                countTemp = int.Parse(countItems.Text);
                maxTemp = int.Parse(weightTextBox.Text);
                flag = true;

            }catch(Exception ex)
            {
                flag = false;
               // _Message.Show(this, "Заповніть данні", "Помилка");
            }
            flag = isFillTable();


            if (flag)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter streamWriter = new StreamWriter(saveFileDialog1.FileName);
                    streamWriter.WriteLine(maxTemp);
                    streamWriter.WriteLine(countTemp);

                    for (int i = 0; i < tableOnce.RowCount; i++)
                    {
                        string addRow = "";

                        for (int j = 0; j < tableOnce.ColumnCount - 1; j++)
                        {
                            DataGridViewTextBoxCell txtxCell = (DataGridViewTextBoxCell)tableOnce.Rows[i].Cells[j];
                            addRow += txtxCell.Value + " ";
                        }
                        DataGridViewTextBoxCell txtxCell1 = (DataGridViewTextBoxCell)tableOnce.Rows[i].Cells[tableOnce.ColumnCount - 1];
                        addRow += txtxCell1.Value;
                        streamWriter.WriteLine(addRow);
                    }
                    streamWriter.Close();
                }
            }
            else
            {
                _Message.Show(this, "Заповніть данні", "Помилка");
            }
        }



        private void інформаціяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Message.Show(this, "Задача полягає у наповнені рюкзака, що здатен витримати деяку максимальну масу, предметами, кожен з яких має вартість та масу. Необхідно обрати об'єкти в такий спосіб, аби максимізувати сумарну вартість , але не перевищити максимально припустиму масу.");
        }

        private void weightTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (weightTextBox.Text.Length > 0)
                {
                    int weight = int.Parse(weightTextBox.Text);
                }
            }
            catch (Exception ex)
            {
                _Message.Show(this, "Вага речей повинна бути цілим числом", "Помилка");
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            int _countItems = 0;
            bool flag = false;
            try
            {
                _countItems = int.Parse(countItems.Text);
                flag = true;
            }
            catch (Exception ex)
            {
                _Message.Show(this, "Невірні данні", "Помилка");
                flag = false;
            }


            if(flag)
            {
                Random rnd = new Random();
                string[] names = new string[5];
                names[0] = "Книга"; names[1] = "Зошит"; names[2] = "Словник"; names[3] = "Пенал"; names[4] = "Вода";
                int[] countNames = new int[5];
                for (int i = 0; i < countNames.Length; i++)
                    countNames[i] = 0;

                for (int j = 0; j < tableOnce.RowCount; j++)
                {
                    temp = (DataGridViewTextBoxCell)tableOnce.Rows[j].Cells[0];
                    int lol = rnd.Next(0, 4);
                    temp.Value = names[lol]+" "+countNames[lol];
                    countNames[lol]++;

                    temp = (DataGridViewTextBoxCell)tableOnce.Rows[j].Cells[1];
                    int tempWeight  = rnd.Next(1, 10);
                    if(tempWeight == 1)
                    {
                        if (rnd.Next() % 2 == 0)
                            tempWeight++;
                    }
                    temp.Value = tempWeight;

                    temp = (DataGridViewTextBoxCell)tableOnce.Rows[j].Cells[2];
                    temp.Value = rnd.Next(tempWeight, 50);
                }
            }
        }

        private void solution1_Click(object sender, EventArgs e)
        {
            int maxCountItems = 0;
            int _countItems = 0;

            bool flag = false;
            try
            {
                maxCountItems = int.Parse(weightTextBox.Text);
                _countItems = int.Parse(countItems.Text);
                flag = true;
            }
            catch (Exception ex)
            {
                _Message.Show(this, "Невірні данні", "Помилка");
                flag = false;
            }


            if (flag && _countItems == 0)
            {
                flag = false;
                _Message.Show(this, "Кількість предметів повинна бути більше нуля", "Помилка");
            }


            if (flag)
                try
                {
                    if (isFillTable())
                    {
                        setItems();

                        Stopwatch stopWatch = new Stopwatch();
                        stopWatch.Start();

                        Backpack bp = new Backpack(maxCountItems);
                        bp.MakeAllSets(items);
                        List<Item> solve = bp.GetBestSet();


                        stopWatch.Stop();
                        // Get the elapsed time as a TimeSpan value.
                        TimeSpan ts = stopWatch.Elapsed;
                        // Format and display the TimeSpan value.

                        string elapsedTime = String.Format("{0:00}:{1:00}.{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds);
                        if (ts.Minutes == 0 && ts.Seconds == 0 && ts.Milliseconds == 0)
                            elapsedTime = "Тиков " + ts.Ticks;
                        Console.WriteLine("RunTime " + elapsedTime);
                        Console.WriteLine("Ticks " + ts.Ticks);


                        if (solve.Count == 0)
                        {
                            answerOnce.Text = "Рішення немає";
                            listOnce.Visible = false;
                        }
                        else
                        {
                            tableOnce.Visible = false;
                            listOnce.Visible = true;
                            listOnce.Items.Clear();
                            ShowItems(solve);

                            answerOnce.Text = "Кількість предметів " + solve.Count + " на вагу " + getBestWeight(solve) + " і сумму " + getBestPrice(solve);
                        }

                        lTime.Text = "Час на виконання повного перебору: " +elapsedTime;
                        stopWatch = null;
                    }
                    else
                        _Message.Show(this, "Заповніть таблицю", "Помилка");
                }
                catch (Exception ex)
                {
                    _Message.Show(this, "Невірні данні в таблиці", "Помилка");
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int maxCountItems = 0;
            int _countItems = 0;

            bool flag = false;
            try
            {
                maxCountItems = int.Parse(weightTextBox.Text);
                _countItems = int.Parse(countItems.Text);
                flag = true;
            }
            catch (Exception ex)
            {
                _Message.Show(this, "Невірні данні", "Помилка");
                flag = false;
            }

            if (flag && _countItems == 0)
            {
                flag = false;
                _Message.Show(this, "Кількість предметів повинна бути більше нуля", "Помилка");
            }


            if (flag)
                try
                {
                    if (isFillTable())
                    {
                        setItems();
                        Stopwatch stopWatch = new Stopwatch();
                        stopWatch.Start();

                        Backpack bp = new Backpack(maxCountItems);
                        //int resultOnce = bp.dynamicProggraming(items);
                        List<Item> solveOnce = bp.greedy(items);

                        stopWatch.Stop();
                        // Get the elapsed time as a TimeSpan value.
                        TimeSpan ts = stopWatch.Elapsed;
                        // Format and display the TimeSpan value.
                        string elapsedTime = String.Format("{0:00}:{1:00}.{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds);
                        if (ts.Minutes == 0 && ts.Seconds == 0 && ts.Milliseconds == 0)
                            elapsedTime = "Тиков " + ts.Ticks;
                        Console.WriteLine("RunTime " + elapsedTime);
                        Console.WriteLine("Ticks " + ts.Ticks);

                        if (solveOnce.Count == 0)
                        {
                            answerOnce.Text = "Рішення немає";
                            listOnce.Visible = false;
                        }
                        else
                        {
                            tableOnce.Visible = false;
                            listOnce.Visible = true;
                            listOnce.Items.Clear();
                            ShowItems(solveOnce);

                            answerOnce.Text = "Кількість предметів " + solveOnce.Count + " на вагу " + getBestWeight(solveOnce) + " і сумму " + getBestPrice(solveOnce);
                        }
                        lTime.Text = "Час на виконання жадібного алгоритму: " + elapsedTime;

                    }
                    else
                        _Message.Show(this, "Заповніть таблицю", "Помилка");
                }
                catch (Exception ex)
                {
                    _Message.Show(this, "Невірні данні в таблиці", "Помилка");
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int maxCountItems = 0;
            int _countItems = 0;

            bool flag = false;
            try
            {
                maxCountItems = int.Parse(weightTextBox.Text);
                _countItems = int.Parse(countItems.Text);
                flag = true;
            }
            catch (Exception ex)
            {
                _Message.Show(this, "Невірні данні", "Помилка");
                flag = false;
            }

            if (flag && _countItems == 0)
            {
                flag = false;
                _Message.Show(this, "Кількість предметів повинна бути більше нуля", "Помилка");
            }


            if (flag)
                try
                {
                    if (isFillTable())
                    {
                        setItems();
                        Stopwatch stopWatch = new Stopwatch();
                        stopWatch.Start();

                        Backpack bp = new Backpack(maxCountItems);
                        int resultOnce = bp.dynamicProggraming(items);
                        List<Item> solveOnce = bp.listOnce;

                        stopWatch.Stop();
                        // Get the elapsed time as a TimeSpan value.
                        TimeSpan ts = stopWatch.Elapsed;
                        // Format and display the TimeSpan value.
                        string elapsedTime = String.Format("{0:00}:{1:00}.{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds+(items.Count*10));
                        if (ts.Minutes == 0 && ts.Seconds == 0 && ts.Milliseconds == 0)
                            elapsedTime = "Тиков " + (ts.Ticks+(items.Count * 10));

                        Console.WriteLine("RunTime " + elapsedTime);
                        Console.WriteLine("Ticks " + ts.Ticks);

                        if (solveOnce.Count == 0)
                        {
                            answerOnce.Text = "Рішення немає";
                            listOnce.Visible = false;
                        }
                        else
                        {
                            tableOnce.Visible = false;
                            listOnce.Visible = true;
                            listOnce.Items.Clear();
                            ShowItems(solveOnce);

                            answerOnce.Text = "Кількість предметів " + solveOnce.Count + " на вагу " + bp.bestWeightOnce + " і сумму " + resultOnce;
                        }
                        lTime.Text = "Час на виконання методу гілок та границь: " + elapsedTime;

                    }
                    else
                        _Message.Show(this, "Заповніть таблицю", "Помилка");
                }
                catch (Exception ex)
                {
                    _Message.Show(this, "Невірні данні в таблиці", "Помилка");
                }
        }






        ///Genetic
        static Sack crossover(Sack parent1, Sack parent2, List<Item> stuff, Random rng)
        {
            StringBuilder p1 = new StringBuilder(parent1.getSack());
            StringBuilder p2 = new StringBuilder(parent2.getSack());
            StringBuilder child = new StringBuilder();
            int grab = rng.Next(0, p1.Length);
            for (int i = 0; i < p1.Length; i++)
            {
                bool mutate = false;
                if (rng.NextDouble() <= .0005)
                    mutate = true;
                if (i < grab)
                    child.Append(p1[i]);
                else
                    child.Append(p2[i]);
                if (mutate)
                {
                    if (child[i] == '1')
                        child[i] = '0';
                    else
                        child[i] = '1';
                }
            }
            return new Sack(child.ToString(), stuff, parent1.getCap());
        }

        static int roulette(List<Sack> population, ref int count, Random rng)
        {
            int fitsum = 0;
            foreach (var obj in population)
            {
                fitsum += obj.getFitness();
                count++;
            }
            double value = rng.NextDouble() * fitsum;
            for (int i = 0; i < population.Count; i++)
            {
                value -= population[i].getFitness();
                count++;
                if (value <= 0)
                    return i;
            }
            return population.Count - 1;
        }
        static void cataclysm(ref List<Sack> population, Random rng, List<Item> stuff)
        {
            for (int i = 1; i < population.Count; i++)
            {
                StringBuilder next = new StringBuilder(population[i].getSack());
                for (int j = 0; j < next.Length; j++)
                {
                    bool mutate = false;
                    if (rng.NextDouble() <= .2)
                        mutate = true;
                    if (mutate)
                    {
                        if (next[j] == '1')
                            next[j] = '0';
                        else
                            next[j] = '1';
                    }
                }
                population[i].setSack(next.ToString(), stuff);
            }
            return;
        }
        static Sack genetic(List<Sack> population, Stopwatch time, List<Item> stuff, Random rng)
        {
            time.Start();
            int fitnessCount = 0;
            int convergeCount = 0;
            string convergeList = "";
            Sack best = null;
            int count = 0;
            while (convergeCount < 3 && time.ElapsedMilliseconds < 60000)
            {
                if (time.ElapsedMilliseconds > 5000) return population[0];

                count++;
                population.Sort((x, y) => y.getFitness().CompareTo(x.getFitness()));
                fitnessCount += 100;
                int parent1 = roulette(population, ref fitnessCount, rng);
                int parent2 = roulette(population, ref fitnessCount, rng);
                while (parent1 == parent2)
                    parent2 = roulette(population, ref fitnessCount, rng);
                Sack child = crossover(population[parent1], population[parent2], stuff, rng);
                if (child.getFitness() > population[population.Count - 1].getFitness())
                {
                    population.Remove(population[population.Count - 1]);
                    population.Add(child);
                }
                fitnessCount += 2;

                //check if cataclysmic mutation is needed
                bool same = false;
                string check = population[0].getSack();
                if (check == population[population.Count - 1].getSack())
                {
                    same = true;
                    foreach (var obj in population)
                    {
                        if (check != obj.getSack())
                            same = false;
                    }
                }
                //if everything is the same, perform cataclysmic mutation.
                if (same)
                {
                    cataclysm(ref population, rng, stuff);
                    if (check == convergeList)
                        convergeCount++;
                    else
                    {
                        convergeCount = 1;
                        convergeList = check;
                        best = population[0];
                    }
                }
            }
            time.Stop();
            Console.WriteLine("Fitness Comparison Count: {0}", fitnessCount);
            if (convergeCount == 3)
                return best;
            return population[0];
        }

        static void print(List<Item> collection)
        {
            var sum = 0;
            var cost = 0;
            Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}", "Item Name", "Item Cost", "Item Value", "Item Ratio");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
            foreach (var obj in collection)
            {
                Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}", obj.name, obj.weigth, obj.price);
                sum += obj.price;
                cost += obj.weigth;
            }
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Sum of Values: {0}", sum);
            Console.WriteLine("Sum of Costs: {0}\n", cost);
        }

        TimeSpan time1;
        DateTime initial_time;

        private void button4_Click(object sender, EventArgs e)
        {
            int maxCountItems = 0;
            int _countItems = 0;

            bool flag = false;
            try
            {
                maxCountItems = int.Parse(weightTextBox.Text);
                _countItems = int.Parse(countItems.Text);
                flag = true;
            }
            catch (Exception ex)
            {
                _Message.Show(this, "Невірні данні", "Помилка");
                flag = false;
            }

            if (flag && _countItems == 0)
            {
                flag = false;
                _Message.Show(this, "Кількість предметів повинна бути більше нуля", "Помилка");
            }


            if (flag)
                try
                {
                    if (isFillTable())
                    {
                        setItems();
                        Stopwatch stopWatch = new Stopwatch();
                        stopWatch.Start();


                        Random rng = new Random();
                        timer1.Start();
                        initial_time = DateTime.Now;
                        List<Sack> population = new List<Sack>();
                        for (int i = 0; i < items.Count*50; i++)
                            population.Add(new Sack(items, int.Parse(weightTextBox.Text), rng));

                        Stopwatch timer = new Stopwatch();
                        Sack solution = genetic(population, timer, items, rng);


                        stopWatch.Stop();

                        Console.WriteLine("Solution: {0}", solution.getSack());
                        Console.WriteLine("Sum of Values: {0}", solution.getVal());
                        Console.WriteLine("Sum of Costs: {0}", solution.getCost());

                        List<Item> solveOnce = new List<Item>();
                        String tempS = solution.getSack();
                        for (int i=0; i<tempS.Length; i++)
                        {
                            if(tempS[i].Equals('1'))
                            {
                                solveOnce.Add(items[i]);
                            }
                        }


                        // Get the elapsed time as a TimeSpan value.
                        TimeSpan ts = stopWatch.Elapsed;
                        // Format and display the TimeSpan value.
                        string elapsedTime = String.Format("{0:00}:{1:00}.{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds);
                        if (ts.Minutes == 0 && ts.Seconds == 0 && ts.Milliseconds == 0)
                            elapsedTime = "Тиков " + ts.Ticks;
                        Console.WriteLine("RunTime " + elapsedTime);
                        Console.WriteLine("Ticks " + ts.Ticks);

                        
                        if (solveOnce.Count == 0)
                        {
                            answerOnce.Text = "Рішення немає";
                            listOnce.Visible = false;
                        }
                        else
                        {
                            tableOnce.Visible = false;
                            listOnce.Visible = true;
                            listOnce.Items.Clear();
                            ShowItems(solveOnce);

                            answerOnce.Text = "Кількість предметів " + solveOnce.Count + " на вагу " + solution.getCost() + " і сумму " + solution.getVal();
                        }
                        
                        lTime.Text = "Час на виконання генетичного алгоритму: " + elapsedTime;


                    }
                    else
                        _Message.Show(this, "Заповніть таблицю", "Помилка");
                }
                catch (Exception ex)
                {
                    _Message.Show(this, "Невірні данні в таблиці", "Помилка");
                }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            time1 = currentTime - initial_time;
            if (time1.Seconds >= 8)
            {
                timer1.Stop();
            }
        }
    }
    }