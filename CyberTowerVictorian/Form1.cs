using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CyberTowerVictorian
{
    public partial class Form1 : Form
    {
        private Unit _player;
        private Unit _currentEnemy;
        private int _currentFloor;
        private string _currentCategory;
        private List<Item> _currentLoot;
        private bool _battleActive;

        private Timer _playerTimer;
        private Timer _enemyTimer;

        private Panel panel1;
        private RichTextBox richTextBox1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button buttonLoot1;
        private Button buttonLoot2;
        private Button buttonLoot3;

        private Button buttonSaveMonsters;
        private Button buttonSaveItems;

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
            SetupUI();
            ChangeBackground(1);
            StartFloor(1);
        }

        private void InitializeGame()
        {
            _player = new Unit();
            _player.Name = "Странник";
            _player.Category = "Игрок";
            _player.Level = 1;
            _player.HP = 25;
            _player.Damage = 10;

            _currentFloor = 1;
            _battleActive = false;

            _playerTimer = new Timer();
            _playerTimer.Tick += PlayerTimer_Tick;

            _enemyTimer = new Timer();
            _enemyTimer.Tick += EnemyTimer_Tick;

            // Загружаем данные из JSON
            List<Unit> monsters = Monsters.GetAllMonsters();
            List<Item> items = Items.GetAllItems();
        }

        private void SetupUI()
        {
            this.Size = new Size(1000, 700);
            this.Text = "CyberTowerVictorian";

            panel1 = new Panel();
            panel1.Dock = DockStyle.Fill;
            panel1.BackColor = Color.FromArgb(30, 30, 30);
            this.Controls.Add(panel1);

            pictureBox1 = new PictureBox();
            pictureBox1.Location = new Point(50, 100);
            pictureBox1.Size = new Size(200, 300);
            pictureBox1.BackColor = Color.Gray;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Text = "Игрок";
            panel1.Controls.Add(pictureBox1);

            pictureBox2 = new PictureBox();
            pictureBox2.Location = new Point(750, 100);
            pictureBox2.Size = new Size(200, 300);
            pictureBox2.BackColor = Color.Gray;
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Text = "Враг";
            panel1.Controls.Add(pictureBox2);

            richTextBox1 = new RichTextBox();
            richTextBox1.Location = new Point(300, 100);
            richTextBox1.Size = new Size(400, 300);
            richTextBox1.BackColor = Color.Black;
            richTextBox1.ForeColor = Color.White;
            richTextBox1.Font = new Font("Consolas", 10);
            richTextBox1.ReadOnly = true;
            panel1.Controls.Add(richTextBox1);

            buttonLoot1 = new Button();
            buttonLoot1.Location = new Point(300, 450);
            buttonLoot1.Size = new Size(120, 50);
            buttonLoot1.Text = "Лут 1";
            buttonLoot1.Visible = false;
            buttonLoot1.Click += ButtonLoot_Click;
            panel1.Controls.Add(buttonLoot1);

            buttonLoot2 = new Button();
            buttonLoot2.Location = new Point(440, 450);
            buttonLoot2.Size = new Size(120, 50);
            buttonLoot2.Text = "Лут 2";
            buttonLoot2.Visible = false;
            buttonLoot2.Click += ButtonLoot_Click;
            panel1.Controls.Add(buttonLoot2);

            buttonLoot3 = new Button();
            buttonLoot3.Location = new Point(580, 450);
            buttonLoot3.Size = new Size(120, 50);
            buttonLoot3.Text = "Лут 3";
            buttonLoot3.Visible = false;
            buttonLoot3.Click += ButtonLoot_Click;
            panel1.Controls.Add(buttonLoot3);

            // Кнопки для сохранения в JSON (как в лекции)
            buttonSaveMonsters = new Button();
            buttonSaveMonsters.Location = new Point(50, 20);
            buttonSaveMonsters.Size = new Size(120, 50);
            buttonSaveMonsters.Text = "Сохранить монстров";
            buttonSaveMonsters.Click += ButtonSaveMonsters_Click;
            panel1.Controls.Add(buttonSaveMonsters);

            buttonSaveItems = new Button();
            buttonSaveItems.Location = new Point(180, 20);
            buttonSaveItems.Size = new Size(120, 50);
            buttonSaveItems.Text = "Сохранить предметы";
            buttonSaveItems.Click += ButtonSaveItems_Click;
            panel1.Controls.Add(buttonSaveItems);
        }

        private void ButtonSaveMonsters_Click(object sender, EventArgs e)
        {
            List<Unit> monsters = Monsters.GetAllMonsters();
            JsonDataManager.SaveMonstersToJson(monsters);
            MessageBox.Show("Монстры сохранены в JSON!");
        }

        private void ButtonSaveItems_Click(object sender, EventArgs e)
        {
            List<Item> items = Items.GetAllItems();
            JsonDataManager.SaveItemsToJson(items);
            MessageBox.Show("Предметы сохранены в JSON!");
        }

        private void ButtonLoot_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton == buttonLoot1)
            {
                TakeLoot(0);
            }
            else if (clickedButton == buttonLoot2)
            {
                TakeLoot(1);
            }
            else if (clickedButton == buttonLoot3)
            {
                TakeLoot(2);
            }
        }

        private void StartFloor(int floor)
        {
            ChangeBackground(floor);
            _currentFloor = floor;

            string[] categories = new string[]
            {
                "БиоМашины",
                "Пришельцы",
                "КиберЗвери",
                "Наемники",
                "Энергетические сущности"
            };

            Random rnd = new Random();
            int categoryIndex = rnd.Next(categories.Length);
            _currentCategory = categories[categoryIndex];

            if (floor == 4 || floor == 8)
            {
                _currentEnemy = Monsters.GetRandomBoss(floor, _currentCategory);

                if (_currentEnemy == null)
                {
                    List<Unit> allMonsters = Monsters.GetAllMonsters();
                    List<Unit> bosses = new List<Unit>();

                    for (int i = 0; i < allMonsters.Count; i++)
                    {
                        Unit m = allMonsters[i];
                        if (m.IsBoss && m.Level == floor)
                        {
                            bosses.Add(m);
                        }
                    }

                    if (bosses.Count > 0)
                    {
                        _currentEnemy = bosses[rnd.Next(bosses.Count)];
                    }
                }
            }
            else
            {
                List<Unit> floorMonsters = Monsters.GetMonstersByFloor(floor);
                List<Unit> categoryMonsters = new List<Unit>();

                for (int i = 0; i < floorMonsters.Count; i++)
                {
                    Unit m = floorMonsters[i];
                    if (m.Category == _currentCategory)
                    {
                        categoryMonsters.Add(m);
                    }
                }

                if (categoryMonsters.Count > 0)
                {
                    _currentEnemy = categoryMonsters[rnd.Next(categoryMonsters.Count)];
                }
                else if (floorMonsters.Count > 0)
                {
                    _currentEnemy = floorMonsters[rnd.Next(floorMonsters.Count)];
                }
            }

            if (_currentEnemy == null)
            {
                richTextBox1.AppendText("Ошибка: не удалось создать врага на этаже " + floor + "\n");
                return;
            }

            _battleActive = true;
            UpdateUI();
            StartBattle();
        }

        private void StartBattle()
        {
            LoadImages();
            int speed = _player.GetTotalAttackSpeed();
            _playerTimer.Interval = speed;
            _playerTimer.Start();
        }

        private void PlayerTimer_Tick(object sender, EventArgs e)
        {
            if (_battleActive == false)
            {
                return;
            }

            _playerTimer.Stop();

            double damage = _player.Attack(_currentEnemy);
            string message = "Вы атаковали " + _currentEnemy.Name + " и нанесли " + damage.ToString("F1") + " урона!";
            richTextBox1.AppendText("\n[СОБЫТИЕ] " + message + "\n");
            richTextBox1.ScrollToCaret();

            if (_currentEnemy.IsAlive() == false)
            {
                _battleActive = false;
                _enemyTimer.Stop();

                string winMessage = "Вы победили " + _currentEnemy.Name + "!";
                richTextBox1.AppendText("\n[СОБЫТИЕ] " + winMessage + "\n");
                richTextBox1.ScrollToCaret();

                HandleVictory();
                return;
            }

            int enemySpeed = _currentEnemy.AttackSpeed;
            _enemyTimer.Interval = enemySpeed;
            _enemyTimer.Start();

            UpdateUI();
        }

        private void EnemyTimer_Tick(object sender, EventArgs e)
        {
            if (_battleActive == false)
            {
                return;
            }

            _enemyTimer.Stop();

            double damage = _currentEnemy.Attack(_player);
            string message = _currentEnemy.Name + " атакует вас и наносит " + damage.ToString("F1") + " урона!";
            richTextBox1.AppendText("\n[СОБЫТИЕ] " + message + "\n");
            richTextBox1.ScrollToCaret();

            if (_player.IsAlive() == false)
            {
                _battleActive = false;
                _playerTimer.Stop();

                richTextBox1.AppendText("\n[СОБЫТИЕ] Вы погибли! Игра окончена.\n");
                richTextBox1.ScrollToCaret();

                MessageBox.Show("Игра окончена! Вы погибли.");
                return;
            }

            int playerSpeed = _player.GetTotalAttackSpeed();
            _playerTimer.Interval = playerSpeed;
            _playerTimer.Start();

            UpdateUI();
        }

        private void HandleVictory()
        {
            _player.Restore();
            _currentLoot = Items.GetRandomLoot(_currentFloor);

            if (_currentLoot.Count >= 3)
            {
                buttonLoot1.Text = _currentLoot[0].Name + " (" + _currentLoot[0].Rarity + ")";
                buttonLoot2.Text = _currentLoot[1].Name + " (" + _currentLoot[1].Rarity + ")";
                buttonLoot3.Text = _currentLoot[2].Name + " (" + _currentLoot[2].Rarity + ")";

                buttonLoot1.Visible = true;
                buttonLoot2.Visible = true;
                buttonLoot3.Visible = true;
            }

            richTextBox1.AppendText("\n[СОБЫТИЕ] Выберите награду:\n");
            richTextBox1.ScrollToCaret();
        }

        private void TakeLoot(int index)
        {
            Item selectedItem = _currentLoot[index];
            EquipItem(selectedItem);

            buttonLoot1.Visible = false;
            buttonLoot2.Visible = false;
            buttonLoot3.Visible = false;

            richTextBox1.AppendText("\n[СОБЫТИЕ] Вы выбрали: " + selectedItem.Name + "\n");
            richTextBox1.ScrollToCaret();

            _currentFloor = _currentFloor + 1;

            if (_currentFloor > 8)
            {
                richTextBox1.AppendText("\n[СОБЫТИЕ] Поздравляем! Вы прошли всю башню!\n");
                richTextBox1.ScrollToCaret();

                MessageBox.Show("Победа! Вы покорили башню!");
                return;
            }

            StartFloor(_currentFloor);
        }

        private void EquipItem(Item item)
        {
            if (item.Category == "Оружие")
            {
                _player.Weapon = item;
                richTextBox1.AppendText("\n[СОБЫТИЕ] Экипировано оружие: " + item.Name + "\n");
            }
            else
            {
                if (item.ItemType == "Шлем")
                {
                    _player.Helmet = item;
                }
                else if (item.ItemType == "Грудь")
                {
                    _player.Chest = item;
                }
                else if (item.ItemType == "Перчатки")
                {
                    _player.Gloves = item;
                }
                else if (item.ItemType == "Штаны")
                {
                    _player.Pants = item;
                }
                else if (item.ItemType == "Ботинки")
                {
                    _player.Boots = item;
                }

                richTextBox1.AppendText("\n[СОБЫТИЕ] Экипирована броня: " + item.Name + "\n");
            }

            UpdateUI();
        }

        private void UpdateUI()
        {
            richTextBox1.Clear();

            string floorText = "===== ЭТАЖ " + _currentFloor + " =====\n";
            richTextBox1.AppendText(floorText);

            string locationText = "Локация: " + _currentCategory + "\n\n";
            richTextBox1.AppendText(locationText);

            richTextBox1.AppendText("--- ИГРОК ---\n");

            string hpText = "HP: " + _player.CurrentHP.ToString("F0") + "/" + (_player.HP + GetArmorBonusHP()).ToString("F0") + "\n";
            richTextBox1.AppendText(hpText);

            string armorText = "Броня: " + _player.CurrentArmor.ToString("F0") + "\n";
            richTextBox1.AppendText(armorText);

            string damageText = "Урон: " + _player.GetTotalDamage().ToString("F1") + "\n";
            richTextBox1.AppendText(damageText);

            string speedText = "Скорость: " + _player.GetTotalAttackSpeed() + "мс\n";
            richTextBox1.AppendText(speedText);

            string critText = "Крит: " + _player.GetTotalCritChance().ToString("F0") + "% x" + _player.GetTotalCritMultiplier().ToString("F1") + "\n";
            richTextBox1.AppendText(critText);

            string evasionText = "Уклонение: " + _player.GetTotalEvasion().ToString("F0") + "%\n";
            richTextBox1.AppendText(evasionText);

            if (_player.Weapon != null)
            {
                string weaponText = "Оружие: " + _player.Weapon.Name + "\n";
                richTextBox1.AppendText(weaponText);
            }

            if (_currentEnemy != null)
            {
                richTextBox1.AppendText("\n--- ВРАГ: " + _currentEnemy.Name + " ---\n");

                string enemyHpText = "HP: " + _currentEnemy.HP.ToString("F0") + "\n";
                richTextBox1.AppendText(enemyHpText);

                string enemyArmorText = "Броня: " + _currentEnemy.CurrentArmor.ToString("F0") + "\n";
                richTextBox1.AppendText(enemyArmorText);

                string enemyDamageText = "Урон: " + _currentEnemy.Damage.ToString("F1") + "\n";
                richTextBox1.AppendText(enemyDamageText);
            }

            richTextBox1.ScrollToCaret();
            LoadImages();
        }

        private double GetArmorBonusHP()
        {
            double bonus = 0;
            if (_player.Helmet != null) bonus = bonus + _player.Helmet.HP;
            if (_player.Chest != null) bonus = bonus + _player.Chest.HP;
            if (_player.Gloves != null) bonus = bonus + _player.Gloves.HP;
            if (_player.Pants != null) bonus = bonus + _player.Pants.HP;
            if (_player.Boots != null) bonus = bonus + _player.Boots.HP;
            return bonus;
        }
        private void LoadImages()
        {
            // Загружаем картинку игрока
            pictureBox1.Image = Properties.Resources.bart10;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            // Загружаем картинку врага
            if (_currentEnemy != null)
            {
                pictureBox2.Image = GetMonsterImage(_currentEnemy.Name);
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
        private Image GetMonsterImage(string monsterName)
        {
            // Просто проверяем по имени напрямую
            switch (monsterName)
            {
                //БИОМАШИНЫ
                case "Ржавый дрон":
                    return Properties.Resources.ржавй_дрон; // напиши как у тебя в ресурсах
                case "МутантНосильщик":
                    return Properties.Resources.мутант_носил;
                case "Фантомный хакер":
                    return Properties.Resources.фантомный_хакер;
                case "КиберВампир":
                    return Properties.Resources.кибер_вампир;
                case "Могильные экзо":
                    return Properties.Resources.могильные_экзо;
                case "НекроТехномант":
                    return Properties.Resources.некротехномант;
                case "БаншиСигнал":
                    return Properties.Resources.Банши_сигнал;
                case "Костяной мех":
                    return Properties.Resources.костяной_мех;
                case "Король Серверов":
                    return Properties.Resources.Король_серверов;
                case "Владыка Свалок":
                    return Properties.Resources.владыка_свалок;

                //ИНОПРИШЕЛЕНЦЫ
                case "Личинка ксеноморфа":
                    return Properties.Resources.личинка_ксеноморфа;
                case "Огненный слизень":
                    return Properties.Resources.огненный_слизень;
                case "Телепат Паразит":
                    return Properties.Resources.Телепат_паразит;
                case "Воин улья":
                    return Properties.Resources.воин_улья;
                case "Командир роя":
                    return Properties.Resources.командир_роя;
                case "Суккуб андроид":
                    return Properties.Resources.суккуб_андроид;
                case "Плазматичный":
                    return Properties.Resources.Плазматичный;
                case "Пустота":
                    return Properties.Resources.Пустота;
                case "Архитектор реальности":
                    return Properties.Resources.Архитектор_реальности;
                case "Падший андроид":
                    return Properties.Resources.Падший_андроид;

                //КИБЕРЗВЕРИ
                case "КиберВолк":
                    return Properties.Resources.киберволк;
                case "БронеМедведь":
                    return Properties.Resources.БронеМедведь;
                case "РысьНевидимка":
                    return Properties.Resources.Рысь_невидимка;
                case "Саблезуб3000":
                    return Properties.Resources.Саблезуб3000;
                case "МамонтТанк":
                    return Properties.Resources.мамонт_танк;
                case "ГрифонРазведчик":
                    return Properties.Resources.грифон_разведчик;
                case "Лев3000":
                    return Properties.Resources.Лев3000;
                case "Древний вивернМех":
                    return Properties.Resources.древни_ВивернМех;
                case "ФенрирПрототип":
                    return Properties.Resources.фенрир_прототип;
                case "ХимераСимбионт":
                    return Properties.Resources.химера_симбионт;

                //НАЕМНИКИ
                case "Наемник с лазером":
                    return Properties.Resources.Наемник_с_лазером;
                case "Охранник корпорации":
                    return Properties.Resources.охранник_корпорации;
                case "СнайперНевидимка":
                    return Properties.Resources.снайперНевидимка;
                case "Космодесантник":
                    return Properties.Resources.космодесантник;
                case "Техномаг":
                    return Properties.Resources.техномаг;
                case "КиберАссасин":
                    return Properties.Resources.киберАссасин;
                case "Капитан Стражи":
                    return Properties.Resources.КапитанСтражи;
                case "Хакер9000":
                    return Properties.Resources.Хакер9000;
                case "Король Генерал":
                    return Properties.Resources.Король_Генерал;
                case "Темный паладин":
                    return Properties.Resources.Темный_паладин;

                //ЭНЕРГОСУЩНОСТИ
                case "Плазмалоид":
                    return Properties.Resources.Плазмалоид;
                case "ГидроДрон":
                    return Properties.Resources.ГидроДрон;
                case "КристаллГолем":
                    return Properties.Resources.КристаллГолем;
                case "Электрический шторм":
                    return Properties.Resources.Электрический_Шторм;
                case "МагмаМех":
                    return Properties.Resources.МагмаМех;
                case "Ледяной синтет":
                    return Properties.Resources.ЛедянойСинтет;
                case "Элементаль хаоса":
                    return Properties.Resources.Элементаль_хаоса;
                case "Древний каменный страж":
                    return Properties.Resources.Древний_каменныйСтраж;
                case "Повелитель стихий":
                    return Properties.Resources.Повелитель_стихий;
                case "Аномалия пространства":
                    return Properties.Resources.Аномалия_Пространства;

                default:
                    Bitmap empty = new Bitmap(200, 300);
                    using (Graphics g = Graphics.FromImage(empty))
                    {
                        g.Clear(Color.Gray);
                        g.DrawString("Нет фото", new Font("Arial", 12), Brushes.White, 60, 140);
                    }
                    return empty;
            }
        }
        private void ChangeBackground(int floors)
        {
            switch (floors)
            {
                case 1:
                    panel1.BackgroundImage = Properties.Resources.Этаж1; 
                    break;
                case 2:
                    panel1.BackgroundImage = Properties.Resources.Этаж2;
                    break;
                case 3:
                    panel1.BackgroundImage = Properties.Resources.Этаж3;
                    break;
                case 4:
                    panel1.BackgroundImage = Properties.Resources.Этаж4;
                    break;
                case 5:
                    panel1.BackgroundImage = Properties.Resources.Этаж5;
                    break;
                case 6:
                    panel1.BackgroundImage = Properties.Resources.Этаж6;
                    break;
                case 7:
                    panel1.BackgroundImage = Properties.Resources.Этаж7;
                    break;
                case 8:
                    panel1.BackgroundImage = Properties.Resources.Этаж8;
                    break;
            }
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}