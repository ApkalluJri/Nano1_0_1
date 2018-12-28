using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FormsSystem_TTPageSlider : System.Web.UI.UserControl
{
    protected const int SLIDERWIDTH = 250;
    protected const int SLIDERHEIGHT = 34;
    protected const int SLIDERTICKS = 50;

    private GridView grdMov;
    public GridView GrdMov
    {
        get { return grdMov; }
        set { grdMov = value; }
    }
    public Int32 idProceso { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        string clientID = grdMov.ClientID;

        if (!IsPostBack)
        {
            RSPagination.ItemType = Telerik.Web.UI.SliderItemType.Tick;
            RSPagination.MinimumValue = 1;          
            RSPagination.SmallChange = 1;
            RSPagination.LargeChange = 10;
            txtpage.Text = "1";
            RSPagination.Height = SLIDERHEIGHT;
            RSPagination.TrackPosition = Telerik.Web.UI.SliderTrackPosition.BottomRight;

            SetSliderWidth();
            if (Session["Page"] != null)
            {
                string[] page =Session["Page"].ToString().Split(':');
                if (page[0] == this.idProceso.ToString() && this.idProceso > 0)
                    sliderPagination(int.Parse(page[1]));
                else
                    Session.Remove("Page");
            }
            
        }
    }

    protected void RSPagination_OnValueChanged(object sender, EventArgs e)
    {
        grdMov.PageIndex = int.Parse(RSPagination.Value.ToString()) - 1;
        grdMov.DataBind();
        txtpage.Text = RSPagination.Value.ToString();
        Session["Page"] = idProceso.ToString() + ":" + (RSPagination.Value - 1).ToString();
    }

    protected void btnRSPaginationFirst_Click(object sender, EventArgs e)
    {
        RSPagination.Value = 1;
        RSPagination.MinimumValue = 1;

        if (grdMov.PageCount < SLIDERTICKS)
            RSPagination.MaximumValue = grdMov.PageCount;
        else
            RSPagination.MaximumValue = SLIDERTICKS;
        
        RSPagination.DataBind();
        grdMov.PageIndex = 0;
        grdMov.DataBind();
        txtpage.Text = RSPagination.Value.ToString();
        Session.Remove("Page");
    }

    protected void btnRSPaginationUnitDecreased_Click(object sender, EventArgs e)
    {
        int value =int.Parse(RSPagination.Value.ToString()) - 1;

        if (value < RSPagination.MinimumValue && value - (SLIDERTICKS - 1)> 0)
        {
            RSPagination.Value = value;
            RSPagination.MinimumValue = value - (SLIDERTICKS - 1);
            RSPagination.MaximumValue = value;
            RSPagination.DataBind();
            grdMov.PageIndex = value - 1;
            grdMov.DataBind();
        }
        else if (value < RSPagination.MinimumValue && value - (SLIDERTICKS - 1) <= 0)
        {
            if (value > 0)
            {
                RSPagination.Value = value;
                RSPagination.MinimumValue = 1;
                RSPagination.MaximumValue = value;
                RSPagination.DataBind();
                grdMov.PageIndex = value - 1;
                grdMov.DataBind();
            }
        }
        else if (value > 0)
        {
            RSPagination.Value = value;
            RSPagination.DataBind();
            grdMov.PageIndex = value - 1;
            grdMov.DataBind();
        }

        txtpage.Text = RSPagination.Value.ToString();
        Session["Page"] = idProceso.ToString() + ":" + (value - 1).ToString();
    }

    protected void btnRSPaginationUnitIncreased_Click(object sender, EventArgs e)
    {
        int value = int.Parse(RSPagination.Value.ToString()) + 1;

        if (value > RSPagination.MaximumValue && value + (SLIDERTICKS - 1) < grdMov.PageCount)
        {
            RSPagination.Value = value;
            RSPagination.MinimumValue = value;
            RSPagination.MaximumValue = value + (SLIDERTICKS - 1);
            RSPagination.DataBind();
            grdMov.PageIndex = value - 1;
            grdMov.DataBind();
        }
        else if (value > RSPagination.MaximumValue && value + (SLIDERTICKS - 1) >= grdMov.PageCount)
        {
            if (value <= grdMov.PageCount)
            {
                RSPagination.Value = value;
                RSPagination.MinimumValue = value;
                RSPagination.MaximumValue = grdMov.PageCount;
                RSPagination.DataBind();
                grdMov.PageIndex = value - 1;
                grdMov.DataBind();
            }
        }
        else if (value <= grdMov.PageCount)
        {
            RSPagination.Value = value;
            RSPagination.DataBind();
            grdMov.PageIndex = value - 1;
            grdMov.DataBind();
        }
        txtpage.Text = RSPagination.Value.ToString();
        Session["Page"] = idProceso.ToString() + ":" + (value - 1).ToString();
    }

    protected void btnRSPaginationLast_Click(object sender, EventArgs e)
    {
        RSPagination.Value = grdMov.PageCount;
        
        if (grdMov.PageCount < SLIDERTICKS)
            RSPagination.MinimumValue = 1;
        else
            RSPagination.MinimumValue = grdMov.PageCount - (SLIDERTICKS - 1);
        
        RSPagination.MaximumValue = RSPagination.Value;
        RSPagination.DataBind();
        grdMov.PageIndex = int.Parse(RSPagination.Value.ToString()) - 1;
        grdMov.DataBind();
        txtpage.Text = RSPagination.Value.ToString();
        Session["Page"] = idProceso.ToString() + ":" + (RSPagination.Value - 1).ToString();
    }

    protected void btnRSPaginationFastDecreased_Click(object sender, EventArgs e)
    {
        int value = int.Parse(RSPagination.MinimumValue.ToString()) - SLIDERTICKS;

        if (value <= 1)
        {
            if (grdMov.PageCount < SLIDERTICKS)
                RSPagination.MaximumValue = grdMov.PageCount;
            else
                RSPagination.MaximumValue = SLIDERTICKS;
            RSPagination.MinimumValue = 1;
        }
        else
        {
            RSPagination.MinimumValue -= SLIDERTICKS;
            RSPagination.MaximumValue -= SLIDERTICKS;
        }
        RSPagination.Value = RSPagination.MinimumValue;
        RSPagination.DataBind();
        grdMov.PageIndex = int.Parse(RSPagination.Value.ToString()) - 1;
        grdMov.DataBind();
        txtpage.Text = RSPagination.Value.ToString();
        Session["Page"] = idProceso.ToString() + ":" + (RSPagination.Value - 1).ToString();
    }

    protected void btnRSPaginationFastIncreased_Click(object sender, EventArgs e)
    {
        int value =int.Parse(RSPagination.MaximumValue.ToString()) + SLIDERTICKS;

        if (value > grdMov.PageCount)
        {
            RSPagination.MaximumValue = grdMov.PageCount;
            if (grdMov.PageCount < SLIDERTICKS)
                RSPagination.MinimumValue = 1;
            else
                RSPagination.MinimumValue = grdMov.PageCount - SLIDERTICKS;

            RSPagination.Value = RSPagination.MaximumValue;
        }
        else
        {
            RSPagination.MinimumValue += SLIDERTICKS;
            RSPagination.MaximumValue += SLIDERTICKS;
            RSPagination.Value = RSPagination.MinimumValue;
        }

        RSPagination.DataBind();
        grdMov.PageIndex =int.Parse(RSPagination.Value.ToString()) - 1;
        grdMov.DataBind();
        txtpage.Text = Convert.ToString(RSPagination.Value);
        Session["Page"] = idProceso.ToString() + ":" + (RSPagination.Value - 1).ToString();
    }

    public void sliderPagination(int indice)
    {
        int minValue = (indice + 1) - 25;
        int maxValue = (indice + 1) + 24;

        if (grdMov.PageCount > SLIDERTICKS)
        {
            if (minValue <= 0)
            {
                RSPagination.Value = indice + 1;
                RSPagination.MinimumValue = 1;
                RSPagination.MaximumValue = SLIDERTICKS;
                RSPagination.DataBind();
                grdMov.PageIndex = indice;
                grdMov.DataBind();
            }
            else if (maxValue > grdMov.PageCount)
            {
                RSPagination.Value = indice + 1;
                RSPagination.MinimumValue = (grdMov.PageCount) - (SLIDERTICKS - 1);
                RSPagination.MaximumValue = grdMov.PageCount;
                RSPagination.DataBind();
                grdMov.PageIndex = indice;
                grdMov.DataBind();
            }
            else
            {
                RSPagination.Value = indice + 1;
                RSPagination.MinimumValue = minValue;
                RSPagination.MaximumValue = maxValue;
                RSPagination.DataBind();
                grdMov.PageIndex = indice;
                grdMov.DataBind();
            }
        }
        else
        {
            RSPagination.Value = indice + 1;
            RSPagination.MinimumValue = 1;
            RSPagination.MaximumValue = grdMov.PageCount;
            RSPagination.DataBind();
            grdMov.PageIndex = indice;
        }
        txtpage.Text = Convert.ToString(RSPagination.Value);
        Session["Page"] = idProceso.ToString() + ":" + indice.ToString();
    }

    public void sliderFilter()
    {
        SetSliderWidth();                

        RSPagination.Value = 1;
        RSPagination.DataBind();
        txtpage.Text = RSPagination.Value.ToString();
    }

    protected void SetSliderWidth() 
    {
        if (grdMov.PageCount <= 1)
            SetControlsVisibility(false);
        else if (grdMov.PageCount < SLIDERTICKS && grdMov.PageCount > 1)
        {
            SetControlsVisibility(true);
            RSPagination.MinimumValue = 1;
            RSPagination.MaximumValue = grdMov.PageCount;
            
            if (grdMov.PageCount > (SLIDERTICKS/2))
                RSPagination.Width = (grdMov.PageCount * Convert.ToInt32(SLIDERWIDTH * 0.9) / SLIDERTICKS);
            else
                RSPagination.Width = (grdMov.PageCount * Convert.ToInt32(SLIDERWIDTH * 1.8) / SLIDERTICKS);

            //btnRSPaginationFastDecreased.Visible = false;
            //btnRSPaginationFastIncreased.Visible = false;

            if (grdMov.PageCount <= 1)
                SetControlsVisibility(false);
        }
        else
        {
            RSPagination.MinimumValue = 1;
            RSPagination.MaximumValue = SLIDERTICKS;
            RSPagination.Width = SLIDERWIDTH;
            SetControlsVisibility(true);
        }
    }

    protected void LBGo_Click(object sender, EventArgs e)
    {
        if (this.txtpage.Text != "")
        {
            int pageNumber = int.Parse(this.txtpage.Text);

            if (pageNumber <= grdMov.PageCount && pageNumber > 0)
            {
                grdMov.PageIndex = (int.Parse(this.txtpage.Text)) - 1;
                sliderPagination((int.Parse(this.txtpage.Text)) - 1);
            }
            else if (pageNumber > grdMov.PageCount)
            {
                grdMov.PageIndex = grdMov.PageCount - 1;
                sliderPagination(grdMov.PageCount - 1);
                txtpage.Text = grdMov.PageCount.ToString();
            }
            else
            {
                grdMov.PageIndex = 0;
                sliderPagination(0);
                txtpage.Text = "1";
            }
        }
    }

    protected void SetControlsVisibility(bool isVisible)
    {
        SliderContainer.Visible = isVisible;
        RSPagination.Visible = isVisible;
        btnRSPaginationFastDecreased.Visible = isVisible;
        btnRSPaginationFastIncreased.Visible = isVisible;
        btnRSPaginationFirst.Visible = isVisible;
        btnRSPaginationLast.Visible = isVisible;
        btnRSPaginationUnitDecreased.Visible = isVisible;
        btnRSPaginationUnitIncreased.Visible = isVisible;
        lblGo.Visible = isVisible;
        txtpage.Visible = isVisible;
        LBgo.Visible = isVisible;
    }
}








