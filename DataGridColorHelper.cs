namespace LinesOfCodeCounter;
internal class DataGridColorHelper
{
    public Color LineColorA => Color.FromArgb(255, 48, 48, 48);
    public Color LineColorB => Color.FromArgb(255, 64, 64, 64);
    public Color BgColor => Color.FromArgb(255, 40, 40, 40);
    public Color TextColor => Color.WhiteSmoke;

    Font font;
    DataGridView dataGridView;
    StringFormat centerFormat;
    SolidBrush BgColorBrush;
    SolidBrush LineColorABrush;
    SolidBrush LineColorBBrush;


    public DataGridColorHelper(DataGridView dataGridView, Font font)
    {
        this.dataGridView = dataGridView;
        this.font = font;

        centerFormat = new StringFormat()
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };

        BgColorBrush = new SolidBrush(BgColor);
        LineColorABrush = new SolidBrush(LineColorA);
        LineColorBBrush = new SolidBrush(LineColorB);
    }


    public void DoColumnHeaderColor(PaintEventArgs e)
    {
        for(int i = 0; i < dataGridView.Columns.Count; i++)
        {
            Rectangle r = dataGridView.GetColumnDisplayRectangle(i, true);
            if(r.Width == 0) continue;
            r = new Rectangle(r.Left, 0, r.Width, dataGridView.ColumnHeadersHeight);
            e.Graphics.FillRectangle(BgColorBrush, r);
            e.Graphics.DrawString(dataGridView.Columns[i].HeaderText, font, Brushes.WhiteSmoke, r, centerFormat);
        }
    }


    public void DoSelectAllColor(DataGridViewCellPaintingEventArgs e)
    {
        if(e.RowIndex == -1 && e.ColumnIndex == -1)
        {
            e.PaintBackground(e.ClipBounds, true);
            Rectangle rect = e.CellBounds;
            e.Graphics.FillRectangle(LineColorBBrush, rect);
            e.PaintContent(e.ClipBounds);
            e.Handled = true;

            RectangleF textRect = new RectangleF(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height);

            e.Graphics.DrawString("Select All", e.CellStyle.Font, Brushes.DimGray, textRect, centerFormat);
        }
    }


    public void DoRowHeaderColor(object sender, DataGridViewRowPostPaintEventArgs e)
    {
        var grid = sender as DataGridView;
        if(grid == null || e == null) return;
        var rowIdx = (e.RowIndex + 1).ToString();

        var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
        if(e.RowIndex % 2 == 0)
            e.Graphics.FillRectangle(LineColorBBrush, headerBounds);
        else
            e.Graphics.FillRectangle(LineColorABrush, headerBounds);
        e.Graphics.DrawString(rowIdx, font, Brushes.WhiteSmoke, headerBounds, centerFormat);
    }


    public void DoRowBackColor(DataGridViewCellFormattingEventArgs e)
    {
        if(e.RowIndex % 2 == 0)
            e.CellStyle.BackColor = LineColorB;
        else
            e.CellStyle.BackColor = LineColorA;

        if(e.RowIndex % 2 == 0)
            dataGridView.Rows[e.RowIndex].HeaderCell.Style.BackColor = LineColorB;
        else
            dataGridView.Rows[e.RowIndex].HeaderCell.Style.BackColor = LineColorA;
    }
}
