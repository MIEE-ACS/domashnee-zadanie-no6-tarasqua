using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace HomeWork_6
{
    class Body
    {
        public int counter = 1;

        public virtual string Type
        {
            get;
            set;
        }

        virtual public double Volume
        {
            get;
            set;
        }

        virtual public double SurfaceArea
        {
            get;
            set;
        }

        virtual public int Counter
        {
            get
            {
                return counter;
            }
        }

        public override string ToString()
        {
            return $"; c объемом {Math.Round(Volume, 2)} м³ и площадью поверхности {Math.Round(SurfaceArea, 2)} м².";
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            Body body = (Body)obj;
            return this.SurfaceArea == body.SurfaceArea && this.Volume == body.Volume;
        }
    }

    class Cube : Body
    {
        double cubeSide, cubeArea, cubeVolume;

        public override string Type
        {
            get
            {
                return "Куб";
            }
        }

        public double Side
        {
            get
            {
                return cubeSide;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Длина стороны куба не может быть отрицатеьной!");
                }
                else if (value == 0)
                {
                    throw new Exception("Длина стороны куба не может быть равной нулю!");
                }
                else
                {
                    cubeSide = value;
                }
            }
        }

        public override double SurfaceArea
        {
            get
            {
                cubeArea = 6 * Math.Pow(cubeSide, 2);
                return cubeArea;
            }
        }

        public override double Volume
        {
            get
            {
                cubeVolume = Math.Pow(cubeSide, 3);
                return cubeVolume;
            }
        }

        public override string ToString()
        {
            return $"{counter}. Куб со стороной {cubeSide} м" + base.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            Cube cube = (Cube)obj;
            return this.SurfaceArea == cube.SurfaceArea && this.Volume == cube.Volume;
        }
    }
    class Ball : Body
    {
        double ballRadius, ballArea, ballVolume;

        public override string Type
        {
            get
            {
                return "Шар";
            }
        }

        public double Radius
        {
            get
            {
                return ballRadius;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Радиус шара не может быть отрицатеьным!");
                }
                else if (value == 0)
                {
                    throw new Exception("Радиус шара не может быть равным нулю!");
                }
                else
                {
                    ballRadius = value;
                }
            }
        }

        public override double SurfaceArea
        {
            get
            {
                ballArea = 4 * Math.PI * Math.Pow(ballRadius, 2);
                return ballArea;
            }
        }

        public override double Volume
        {
            get
            {
                ballVolume = 1.333 * Math.PI * Math.Pow(ballRadius, 3);
                return ballVolume;
            }
        }

        public override string ToString()
        {
            return $"{counter}. Шар с радиусом {ballRadius} м" + base.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            Ball ball = (Ball)obj;
            return this.SurfaceArea == ball.SurfaceArea && this.Volume == ball.Volume;
        }
    }
    class Cone : Body
    {
        double coneHeight, coneRadius, coneArea, coneVolume;

        public override string Type
        {
            get
            {
                return "Конус";
            }
        }

        public double Radius
        {
            get
            {
                return coneRadius;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Радиус конуса не может быть отрицатеьным!");
                }
                else if (value == 0)
                {
                    throw new Exception("Радиус конуса не может быть равным нулю!");
                }
                else
                {
                    coneRadius = value;
                }
            }
        }

        public double Height
        {
            get
            {
                return coneHeight;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Высота конуса не может быть отрицатеьной!");
                }
                else if (value == 0)
                {
                    throw new Exception("Высота конуса не может быть равной нулю!");
                }
                else
                {
                    coneHeight = value;
                }
            }
        }

        public override double SurfaceArea
        {
            get
            {
                coneArea = Math.PI * Math.Pow(coneRadius, 2) + Math.PI * coneRadius * Math.Sqrt(Math.Pow(coneRadius, 2) + Math.Pow(coneHeight, 2));
                return coneArea;
            }
        }

        public override double Volume
        {
            get
            {
                coneVolume = 0.333 * (Math.PI * Math.Pow(coneRadius, 2)) * coneHeight;
                return coneVolume;
            }
        }

        public override string ToString()
        {
            return $"{counter}. Конус с радиусом основания {coneRadius} м и высотой {coneHeight} м" + base.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            Cone cone = (Cone)obj;
            return this.SurfaceArea == cone.SurfaceArea && this.Volume == cone.Volume;
        }
    }

    public partial class MainWindow : Window
    {
        public double sideOfCube, radiusOfBall, radiusOfCone, heightOfCone;
        public int count = 10;


        List<Body> bodies = new List<Body>()
        {
            new Cube() { Side = 5.3 },
            new Cube() { Side = 3.8, counter = 2 },
            new Cube() { Side = 2.2, counter = 3 },

            new Cone() { Radius = 4.5, Height = 2.4, counter = 4 },
            new Cone() { Radius = 3.2, Height = 1.7, counter = 5 },
            new Cone() { Radius = 6.5, Height = 3, counter = 6 },

            new Ball() { Radius = 4.2, counter = 7 },
            new Ball() { Radius = 5.5, counter = 8 },
            new Ball() { Radius = 3.7, counter = 9 },
        };

        public MainWindow()
        {
            InitializeComponent();
            updateListBox(bodies);
        }

        void updateListBox(List<Body> bodies)
        {
            lbBody.Items.Clear();
            foreach (var body in bodies)
            {
                lbBody.Items.Add(body);
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (rbCube.IsChecked == true)
                {
                    sideOfCube = double.Parse(tbSide.Text.Replace('.', ','));
                    Cube cube = new Cube
                    {
                        Side = sideOfCube,
                        counter = count
                    };
                    count++;
                    bodies.Add(cube);
                    updateListBox(bodies);
                }
                else if (rbBall.IsChecked == true)
                {
                    radiusOfBall = double.Parse(tbRadiusOfBall.Text.Replace('.', ','));
                    Ball ball = new Ball
                    {
                        Radius = radiusOfBall,
                        counter = count
                    };
                    count++;
                    bodies.Add(ball);
                    updateListBox(bodies);
                }
                else if (rbCone.IsChecked == true)
                {
                    radiusOfCone = double.Parse(tbRadiusOfCone.Text.Replace('.', ','));
                    heightOfCone = double.Parse(tbHeight.Text.Replace('.', ','));
                    Cone cone = new Cone
                    {
                        Radius = radiusOfCone,
                        Height = heightOfCone,
                        counter = count
                    };
                    count++;
                    bodies.Add(cone);
                    updateListBox(bodies);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Проверьте введенные значения", "Ошибка данных", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка данных", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void rbCube_Checked(object sender, RoutedEventArgs e)
        {

            lbSide.Visibility = Visibility.Visible;
            tbSide.Visibility = Visibility.Visible;

            lbRadius.Visibility = Visibility.Hidden;
            lbHeight.Visibility = Visibility.Hidden;
            tbHeight.Visibility = Visibility.Hidden;
            tbRadiusOfBall.Visibility = Visibility.Hidden;
            tbRadiusOfCone.Visibility = Visibility.Hidden;
        }

        private void rbBall_Checked(object sender, RoutedEventArgs e)
        {
            lbRadius.Visibility = Visibility.Visible;
            tbRadiusOfBall.Visibility = Visibility.Visible;

            lbSide.Visibility = Visibility.Hidden;
            tbSide.Visibility = Visibility.Hidden;
            lbHeight.Visibility = Visibility.Hidden;
            tbHeight.Visibility = Visibility.Hidden;
            tbRadiusOfCone.Visibility = Visibility.Hidden;
        }

        private void rbCone_Checked(object sender, RoutedEventArgs e)
        {
            lbRadius.Visibility = Visibility.Visible;
            lbHeight.Visibility = Visibility.Visible;
            tbHeight.Visibility = Visibility.Visible;
            tbRadiusOfCone.Visibility = Visibility.Visible;

            lbSide.Visibility = Visibility.Hidden;
            tbSide.Visibility = Visibility.Hidden;
            tbRadiusOfBall.Visibility = Visibility.Hidden;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Body[] bodyDeleted = new Body[lbBody.SelectedItems.Count];
            lbBody.SelectedItems.CopyTo(bodyDeleted, 0);

            foreach (var bodyes in bodyDeleted)
            {
                lbBody.Items.Remove(bodyes);
                bodies.Remove(bodyes);
            }

            count = 1;
            foreach (var body in bodies)
            {
                body.counter = count;
                count++;
            }
            updateListBox(bodies);
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (double.Parse(tbExcessOfValueArea.Text) < 0 || double.Parse(tbExcessOfValueVolume.Text) < 0)
                {
                    MessageBox.Show("Значения площади и объема должны быть неотрицательными!");
                    return;
                }

                var buddys = bodies.Where(x => x.SurfaceArea > double.Parse(tbExcessOfValueArea.Text)).Where(x => x.Volume > double.Parse(tbExcessOfValueVolume.Text));

                if (buddys.Count() == 0)
                {
                    MessageBox.Show($"Все фигуры меньшей площади и объема.");
                    return;
                }

                string result = buddys.Aggregate("Объем и площадь больше в фигурах:\n", (s, x) =>
                                s += $"{x.counter}. {x.Type} {Math.Round(x.Volume, 2)} м³, {Math.Round(x.SurfaceArea, 2)} м². \n");

                MessageBox.Show(result);
            }
            catch (FormatException)
            {
                MessageBox.Show("Проверьте введенные значения", "Ошибка данных", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSort_Click(object sender, RoutedEventArgs e)
        {
            string selectedBody = cbBody.Text;
            var selectedBuddy = bodies.Where(x => x.Type == selectedBody);

            if (selectedBuddy.Count() == 0)
            {
                MessageBox.Show("Заданных фигур не найдено");
                return;
            }

            lbBody.Items.Clear();
            foreach (var body in selectedBuddy)
            {
                lbBody.Items.Add(body);
            }

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            updateListBox(bodies);
        }
    }
}
