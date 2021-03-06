﻿using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DXControls
{

    [DesignerAttribute( typeof( EditorSplitPanelDesigner ) )]
    public partial class EditorSplitPanel : UserControl
    {
        public EditorSplitPanel()
        {
            InitializeComponent();
        }

        [Description( "The (Background) Color of the Top, Bottom, Right, Left and Center Panel " )]
        public new System.Drawing.Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                this.LeftPanel.BackColor = value;
                this.RightPanel.BackColor = value;
                this.TopPanel.BackColor = value;
                this.BottomPanel.BackColor = value;
                this.CenterPanel.BackColor = value;     // ?!?
            }
        }

        private bool leftCollapsed;
        private bool rightCollapsed;
        private bool topCollapsed;
        private bool bottomCollapsed;
        private bool gameMode = false;

        [Description("In GameMode only the Center Panel is Visible")]
        public bool GameMode
        {
            get { return this.gameMode; }
            set
            {
                if ( value != this.gameMode )
                {
                    if ( value )
                    {
                        this.leftCollapsed = LeftPanelCollapsed;
                        this.rightCollapsed = RightPanelCollapsed;
                        this.topCollapsed = TopPanelCollapsed;
                        this.bottomCollapsed = BottomPanelCollapsed;
                        LeftPanelCollapsed = true;
                        RightPanelCollapsed = true;
                        TopPanelCollapsed = true;
                        BottomPanelCollapsed = true;
                    }
                    else
                    {
                        LeftPanelCollapsed = this.leftCollapsed;
                        RightPanelCollapsed = this.rightCollapsed;
                        TopPanelCollapsed = this.topCollapsed;
                        BottomPanelCollapsed = this.bottomCollapsed;
                    }
                    this.gameMode = value;
                }
            }
        }

        [Browsable( false )]
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Content )]
        [Description( "The panel left of the middle." )]
        public Control LeftPanel { get { return this.splitLeft.Panel1; } }

        [Browsable( false )]
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Content )]
        [Description( "The panel above the middle." )]
        public Control TopPanel { get { return this.splitTop.Panel1; } }

        [Browsable( false )]
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Content )]
        [Description( "The panel right the middle." )]
        public Control RightPanel { get { return this.splitRight.Panel2; } }

        [Browsable( false )]
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Content )]
        [Description( "The panel below the middle." )]
        public Control BottomPanel { get { return this.splitBottom.Panel2; } }

        [Browsable( false )]
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Content )]
        [Description( "The panel in the middle." )]
        public Control CenterPanel { get { return this.splitTop.Panel2; } }


        [Browsable( false )]
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Content )]
        [Description( "The left split." )]
        public SplitContainer LeftSplit { get { return this.splitLeft; } }

        [Browsable( false )]
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Content )]
        [Description( "The right split." )]
        public SplitContainer RightSplit { get { return this.splitRight; } }

        [Browsable( false )]
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Content )]
        [Description( "The top split." )]
        public SplitContainer TopSplit { get { return this.splitTop; } }

        [Browsable( false )]
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Content )]
        [Description( "The bottom split." )]
        public SplitContainer BottomSplit { get { return this.splitBottom; } }


        [Description( "The left splitter position." )]
        public int LeftSplitPosition
        { 
            get { return this.splitLeft.SplitterDistance; }
            set { this.splitLeft.SplitterDistance = value; }
        }

        [Description( "The right splitter position." )]
        public int RightSplitPosition
        {
            get { return this.splitRight.SplitterDistance; }
            set { this.splitRight.SplitterDistance = value; }
        }

        [Description( "The top splitter position." )]
        public int TopSplitPosition
        {
            get { return this.splitTop.SplitterDistance; }
            set { this.splitTop.SplitterDistance = value; }
        }
        
        [Description( "The bottom splitter position." )]
        public int BottomSplitPosition
        {
            get { return this.splitBottom.SplitterDistance; }
            set { this.splitBottom.SplitterDistance = value; }
        }


        [Browsable( true )]
        [Description( "Indicates if the left panel is collapsed." )]
        public bool LeftPanelCollapsed
        {
            get { return this.splitLeft.Panel1Collapsed; }
            set { this.splitLeft.Panel1Collapsed = value; }
        }

        [Browsable( true )]
        [Description( "Indicates if the right panel is collapsed." )]
        public bool RightPanelCollapsed
        {
            get { return this.splitRight.Panel2Collapsed; }
            set { this.splitRight.Panel2Collapsed = value; }
        }

        [Browsable( true )]
        [Description( "Indicates if the top panel is collapsed." )]
        public bool TopPanelCollapsed
        {
            get { return this.splitTop.Panel1Collapsed; }
            set { this.splitTop.Panel1Collapsed = value; }
        }

        [Browsable( true )]
        [Description( "Indicates if the bottom panel is collapsed." )]
        public bool BottomPanelCollapsed
        {
            get { return this.splitBottom.Panel2Collapsed; }
            set { this.splitBottom.Panel2Collapsed = value; }
        }

    }


    [System.Security.Permissions.PermissionSet( System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust" )] 
    public class EditorSplitPanelDesigner : System.Windows.Forms.Design.ControlDesigner
    {

        public EditorSplitPanelDesigner() { }

        public override void Initialize( IComponent component )
        {
            base.Initialize( component );
            EditorSplitPanel panel = component as EditorSplitPanel;
            //this.EnableDesignMode( panel.TopPanel, "Top" );
            //this.EnableDesignMode( panel.BottomPanel, "Bottom" );
            //this.EnableDesignMode( panel.LeftPanel, "Left" );
            //this.EnableDesignMode( panel.RightPanel, "Right" );
            //this.EnableDesignMode( panel.CenterPanel, "Center" );
            this.EnableDesignMode( panel.TopSplit, "Top" );
            this.EnableDesignMode( panel.BottomSplit, "Bottom" );
            this.EnableDesignMode( panel.LeftSplit, "Left" );
            this.EnableDesignMode( panel.RightSplit, "Right" );
        }

    }

}
