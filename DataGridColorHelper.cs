namespace LinesOfCodeCounter;
internal class DataGridColorHelper
{
    Color lineColorA;
    Color lineColorB;
    Color bgColor;
    DataGridView dataGridView;
    Font font;

    public DataGridColorHelper(Color lineColorA, Color lineColorB, Color bgColor, DataGridView dataGridView, Font font)
    {
        this.lineColorA = lineColorA;
        this.lineColorB = lineColorB;
        this.bgColor = bgColor;
        this.dataGridView = dataGridView;
        this.font = font;
    }

    public void DoColumnHeaderColor(PaintEventArgs e)
    {
        for(int i = 0; i < dataGridView.Columns.Count; i++)
        {
            Rectangle r = dataGridView.GetColumnDisplayRectangle(i, true);
            if(r.Width == 0) continue;
            r = new Rectangle(r.Left, 0, r.Width, dataGridView.ColumnHeadersHeight);
            e.Graphics.FillRectangle(new SolidBrush(bgColor), r);
            var centerFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            e.Graphics.DrawString(dataGridView.Columns[i].HeaderText, font, Brushes.WhiteSmoke, r, centerFormat);
        }
    }

    public void DoSelectAllColor(DataGridViewCellPaintingEventArgs e)
    {
        if(e.RowIndex == -1 && e.ColumnIndex == -1)
        {
            e.PaintBackground(e.ClipBounds, true);
            Rectangle rect = e.CellBounds;
            e.Graphics.FillRectangle(new SolidBrush(lineColorB), rect);
            e.PaintContent(e.ClipBounds);
            e.Handled = true;

            RectangleF textRect = new RectangleF(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString("Select All", e.CellStyle.Font, Brushes.DimGray, textRect, format);
        }
    }

    public void DoRowHeaderColor(object sender, DataGridViewRowPostPaintEventArgs e)
    {
        var grid = sender as DataGridView;
        var rowIdx = (e.RowIndex + 1).ToString();
        var centerFormat = new StringFormat()
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };
        var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
        if(e.RowIndex % 2 == 0)
            e.Graphics.FillRectangle(new SolidBrush(lineColorB), headerBounds);
        else
            e.Graphics.FillRectangle(new SolidBrush(lineColorA), headerBounds);
        e.Graphics.DrawString(rowIdx, font, Brushes.WhiteSmoke, headerBounds, centerFormat);
    }

    public void DoRowBackColor(DataGridViewCellFormattingEventArgs e)
    {
        if(e.RowIndex % 2 == 0)
            e.CellStyle.BackColor = lineColorB;
        else
            e.CellStyle.BackColor = lineColorA;

        if(e.RowIndex % 2 == 0)
            dataGridView.Rows[e.RowIndex].HeaderCell.Style.BackColor = lineColorB;
        else
            dataGridView.Rows[e.RowIndex].HeaderCell.Style.BackColor = lineColorA;
    }
}
