using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntiMyco.DataModels.TechnologicalSchemeDataModel;

namespace AntiMyco.TechnologicalSchemeModule
{
    public partial class Visualization : Form
    {
        TechnologicalSchemeDBContext db;
        ProductionScheme scheme;

        int standartShift = 15;

        int curX = 50;
        int yStage = 300;
        int stageHeight = 400, stageMinWidth = 500;
        int stageArrowWidth = 100;

        int curOpX;
        int opShiftWidth = 20;
        int opShiftHeight = 50;
        int opHeight = 300;
        int opMinWidth = 400;
        int opArrowWidth = 60;

        int curEqX;
        int eqWidth = 200;
        int eqHeight = 200;
        int eqShiftHeight = 40;
        int eqShiftWidth = 15;

        int lowSubY = 850;
        int subHeight = 75;

        public Visualization(TechnologicalSchemeDBContext db, ProductionScheme scheme)
        {
            InitializeComponent();
            this.db = db;
            this.scheme = scheme;

            WindowState = FormWindowState.Maximized;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            curX = 50;
            foreach(var s in scheme.Stages.OrderBy(o => o.OrderInScheme))
            {
                if (s.Operations.Count == 0)
                {
                    DrawEmptyStage(s, e.Graphics);
                }
                else
                {
                    DrawStage(s, e.Graphics);
                }

                DrawStageArrow(e.Graphics, s);
            }

            DrawSubstances(e.Graphics);
            pictureBox1.Width = curX + 50;
        }

        private void DrawEmptyStage(Stage stage, Graphics graphics)
        {
            Font font = new Font("Arial", 20);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            int curWidth = stageMinWidth;
            var sSize = graphics.MeasureString(stage.Name, font);
            if (sSize.Width + standartShift * 2 > curWidth)
                curWidth = (int)sSize.Width + standartShift *2;

            graphics.DrawString(stage.Name, font, drawBrush, curX + standartShift, yStage + standartShift);

            graphics.DrawRectangle(Pens.Red, curX, yStage, curWidth, stageHeight);

            curX += curWidth; 
        }

        private void DrawStageArrow(Graphics graphics, Stage stage)
        {
            Pen arrowPen = new Pen(Color.Black, 3);
            arrowPen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

            var balances = from b in stage.MaterialBalances where b.IdClassNavigation.Name == "Целевой продукт" select b;

            if (balances.Count() == 0)
            {
                graphics.DrawLine(arrowPen, curX, yStage + stageHeight / 2, curX + stageArrowWidth, yStage + stageHeight / 2);
                curX += stageArrowWidth;
            }
            else
            {
                int curWidth = stageArrowWidth;
                int shift = standartShift * 2;
                foreach(var balance in balances)
                {
                    string target = balance.IdSubstanceNavigation.Name;
                    if (balance.ChanfeG != null)
                        target += " " + balance.ChanfeG + " г.";
                    if (balance.ChangeMl != null)
                        target += " " + balance.ChangeMl + " мл.";

                    Font font = new Font("Arial", 14);
                    SolidBrush drawBrush = new SolidBrush(Color.Black);

                    var sSize = graphics.MeasureString(target, font);
                    if (sSize.Width + standartShift * 2 > curWidth)
                        curWidth = (int)sSize.Width + standartShift * 2;

                    graphics.DrawString(target, font, drawBrush, curX + standartShift, yStage - shift + stageHeight / 2);
                    graphics.DrawLine(arrowPen, curX, yStage + stageHeight / 2, curX + curWidth, yStage + stageHeight / 2);
                    shift += standartShift * 2;
                }

                curX += curWidth;
            }
        }

        private void DrawStage(Stage stage, Graphics graphics)
        {
            curOpX = curX + opShiftWidth;

            foreach (var op in stage.Operations.OrderBy(o => o.OrderInStage))
            {
                if(op.EquipmentInvolvedInOperations.Count == 0)
                {
                    DrawEmtyOperation(op, graphics);
                }
                else
                {
                    DrawOperation(op, graphics);
                }

                if (op.OrderInStage != stage.Operations.Count - 1)
                    DrawOperationArrow(graphics);
            }

            Font font = new Font("Arial", 20);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            int curWidth = stageMinWidth;
            int opsWidth = curOpX - curX + standartShift;
            var sSize = graphics.MeasureString(stage.Name, font);
            if (sSize.Width + standartShift * 2 > curWidth)
                curWidth = (int)sSize.Width + standartShift * 2;
            if (opsWidth > curWidth)
                curWidth = opsWidth;

            graphics.DrawString(stage.Name, font, drawBrush, curX + standartShift, yStage + standartShift);

            graphics.DrawRectangle(Pens.Red, curX, yStage, curWidth, stageHeight);

            var rawMaterials = from s in stage.MaterialBalances where s.IdClassNavigation.Name == "Сырьё" select s;
            if (rawMaterials.Count() != 0)
                WriteRawMaterials(graphics, rawMaterials.ToList(), curWidth);

            var wastes = from s in stage.MaterialBalances where s.IdClassNavigation.Name == "Отходы" select s;
            if (wastes.Count() != 0)
                WriteWastes(graphics, wastes.ToList(), curWidth);

            curX += curWidth;
        }

        private void DrawEmtyOperation(Operation operation, Graphics graphics)
        {
            Font font = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            int curWidth = opMinWidth;
            var sSize = graphics.MeasureString(operation.Name, font);
            if (sSize.Width + standartShift * 2 > curWidth)
                curWidth = (int)sSize.Width + standartShift * 2;

            graphics.DrawString(operation.Name, font, drawBrush, curOpX + standartShift, yStage + opShiftHeight + standartShift);

            graphics.DrawRectangle(Pens.Blue, curOpX, yStage + opShiftHeight, curWidth, opHeight);

            curOpX += curWidth;
        }

        private void DrawOperationArrow(Graphics graphics)
        {
            Pen arrowPen = new Pen(Color.Black, 2);
            arrowPen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

            graphics.DrawLine(arrowPen, curOpX, yStage + stageHeight / 2, curOpX + opArrowWidth, yStage + stageHeight / 2);

            curOpX += opArrowWidth;
        }

        private void DrawOperation(Operation operation, Graphics graphics)
        {
            curEqX = curOpX + eqShiftWidth;

            foreach(var eq in operation.EquipmentInvolvedInOperations)
            {
                Equipment equipment = eq.IdEquipmentNavigation;
                DrawEq(equipment, graphics);
                curEqX += eqWidth + standartShift;
            }

            Font font = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            int eqsWidth = curEqX - curOpX + standartShift;
            int curWidth = opMinWidth;
            var sSize = graphics.MeasureString(operation.Name, font);
            if (sSize.Width + standartShift * 2 > curWidth)
                curWidth = (int)sSize.Width + standartShift * 2;
            if (eqsWidth > curWidth)
                curWidth = eqsWidth;

            graphics.DrawString(operation.Name, font, drawBrush, curOpX + standartShift, yStage + opShiftHeight + standartShift);

            graphics.DrawRectangle(Pens.Blue, curOpX, yStage + opShiftHeight, curWidth, opHeight);

            curOpX += curWidth;
        }

        private void DrawEq(Equipment equipment, Graphics graphics)
        {
            byte[] bytes = equipment.Macro;
            Image image;
            using (var ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
            }
            
            graphics.DrawImage(image, curEqX, yStage + opShiftHeight + eqShiftHeight + standartShift, eqWidth, eqHeight);
        }

        private void DrawSubstances(Graphics graphics)
        {
            int curWidth = curX - 50;

            graphics.FillRectangle(new SolidBrush(Color.LightGreen), 50, 50, curWidth, subHeight);
            graphics.FillRectangle(new SolidBrush(Color.DarkOrange), 50, lowSubY, curWidth, subHeight);

            Font font = new Font("Arial", 24);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            graphics.DrawString("Сырьё", font, drawBrush, 100, 70);
            graphics.DrawString("Отходы", font, drawBrush, 100, lowSubY + 20);
        }

        private void WriteRawMaterials(Graphics graphics, List<MaterialBalance> balances, int width)
        {
            int midX = curX + width / 2;
            int shift = standartShift * 2;
            Font font = new Font("Arial", 14);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            foreach (var b in balances)
            {
                string line = b.IdSubstanceNavigation.Name;
                if (b.ChanfeG != null)
                    line += " " + b.ChanfeG + " г.";
                if (b.ChangeMl != null)
                    line += " " + b.ChangeMl + " мл.";

                graphics.DrawString(line, font, drawBrush, midX + standartShift, yStage - shift);
                shift += standartShift * 2;
            }

            Pen arrowPen = new Pen(Color.Black, 3);
            arrowPen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            graphics.DrawLine(arrowPen, midX, 50 + subHeight, midX, yStage);
        }

        private void WriteWastes(Graphics graphics, List<MaterialBalance> balances, int width)
        {
            int midX = curX + width / 2;
            int shift = standartShift * 2;
            Font font = new Font("Arial", 14);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            foreach (var b in balances)
            {
                string line = b.IdSubstanceNavigation.Name;
                if (b.ChanfeG != null)
                    line += " " + b.ChanfeG + " г.";
                if (b.ChangeMl != null)
                    line += " " + b.ChangeMl + " мл.";

                graphics.DrawString(line, font, drawBrush, midX + standartShift, yStage + stageHeight + shift);
                shift += standartShift * 2;
            }

            Pen arrowPen = new Pen(Color.Black, 3);
            arrowPen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            graphics.DrawLine(arrowPen, midX, yStage + stageHeight, midX, lowSubY);
        }
    }
}
