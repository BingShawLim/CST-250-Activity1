namespace VehicleStoreGUIApp
{
    partial class FrmVehicleStore
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grpCreateVehicle = new System.Windows.Forms.GroupBox();
            rdoCar = new System.Windows.Forms.RadioButton();
            rdoMotorcycle = new System.Windows.Forms.RadioButton();
            rdoPickup = new System.Windows.Forms.RadioButton();
            rdoVehicle = new System.Windows.Forms.RadioButton();
            lblVehicleTypeError = new System.Windows.Forms.Label();
            lblMake = new System.Windows.Forms.Label();
            txtMake = new System.Windows.Forms.TextBox();
            lblMakeError = new System.Windows.Forms.Label();
            lblModel = new System.Windows.Forms.Label();
            txtModel = new System.Windows.Forms.TextBox();
            lblModelError = new System.Windows.Forms.Label();
            lblYear = new System.Windows.Forms.Label();
            txtYear = new System.Windows.Forms.TextBox();
            lblYearError = new System.Windows.Forms.Label();
            lblPrice = new System.Windows.Forms.Label();
            txtPrice = new System.Windows.Forms.TextBox();
            lblPriceError = new System.Windows.Forms.Label();
            lblWheels = new System.Windows.Forms.Label();
            txtWheels = new System.Windows.Forms.TextBox();
            lblWheelsError = new System.Windows.Forms.Label();
            lblColor = new System.Windows.Forms.Label();
            txtColor = new System.Windows.Forms.TextBox();
            lblColorError = new System.Windows.Forms.Label();
            lblMiles = new System.Windows.Forms.Label();
            txtMiles = new System.Windows.Forms.TextBox();
            lblMilesError = new System.Windows.Forms.Label();
            btnCreate = new System.Windows.Forms.Button();
            grpSpecialty = new System.Windows.Forms.GroupBox();
            lblSpecialtyBoolean = new System.Windows.Forms.Label();
            rdoSpecialtyYes = new System.Windows.Forms.RadioButton();
            rdoSpecialtyNo = new System.Windows.Forms.RadioButton();
            lblSpecialtyBooleanError = new System.Windows.Forms.Label();
            lblSpecialtyDecimal = new System.Windows.Forms.Label();
            txtSpecialtyDecimal = new System.Windows.Forms.TextBox();
            lblSpecialtyDecimalError = new System.Windows.Forms.Label();
            lblSearch = new System.Windows.Forms.Label();
            txtSearch = new System.Windows.Forms.TextBox();
            btnSearch = new System.Windows.Forms.Button();
            btnClearSearch = new System.Windows.Forms.Button();
            lblSort = new System.Windows.Forms.Label();
            cmbSort = new System.Windows.Forms.ComboBox();
            btnSort = new System.Windows.Forms.Button();
            btnSaveInventory = new System.Windows.Forms.Button();
            btnLoadInventory = new System.Windows.Forms.Button();
            grpInventory = new System.Windows.Forms.GroupBox();
            lstInventory = new System.Windows.Forms.ListBox();
            btnAddToCart = new System.Windows.Forms.Button();
            btnRemoveFromCart = new System.Windows.Forms.Button();
            grpShoppingCart = new System.Windows.Forms.GroupBox();
            lstShoppingCart = new System.Windows.Forms.ListBox();
            btnCheckout = new System.Windows.Forms.Button();
            lblTotalText = new System.Windows.Forms.Label();
            lblTotal = new System.Windows.Forms.Label();
            grpCreateVehicle.SuspendLayout();
            grpSpecialty.SuspendLayout();
            grpInventory.SuspendLayout();
            grpShoppingCart.SuspendLayout();
            SuspendLayout();
            // 
            // grpCreateVehicle
            // 
            grpCreateVehicle.Controls.Add(rdoCar);
            grpCreateVehicle.Controls.Add(rdoMotorcycle);
            grpCreateVehicle.Controls.Add(rdoPickup);
            grpCreateVehicle.Controls.Add(rdoVehicle);
            grpCreateVehicle.Controls.Add(lblVehicleTypeError);
            grpCreateVehicle.Controls.Add(lblMake);
            grpCreateVehicle.Controls.Add(txtMake);
            grpCreateVehicle.Controls.Add(lblMakeError);
            grpCreateVehicle.Controls.Add(lblModel);
            grpCreateVehicle.Controls.Add(txtModel);
            grpCreateVehicle.Controls.Add(lblModelError);
            grpCreateVehicle.Controls.Add(lblYear);
            grpCreateVehicle.Controls.Add(txtYear);
            grpCreateVehicle.Controls.Add(lblYearError);
            grpCreateVehicle.Controls.Add(lblPrice);
            grpCreateVehicle.Controls.Add(txtPrice);
            grpCreateVehicle.Controls.Add(lblPriceError);
            grpCreateVehicle.Controls.Add(lblWheels);
            grpCreateVehicle.Controls.Add(txtWheels);
            grpCreateVehicle.Controls.Add(lblWheelsError);
            grpCreateVehicle.Controls.Add(lblColor);
            grpCreateVehicle.Controls.Add(txtColor);
            grpCreateVehicle.Controls.Add(lblColorError);
            grpCreateVehicle.Controls.Add(lblMiles);
            grpCreateVehicle.Controls.Add(txtMiles);
            grpCreateVehicle.Controls.Add(lblMilesError);
            grpCreateVehicle.Controls.Add(btnCreate);
            grpCreateVehicle.Location = new System.Drawing.Point(12, 12);
            grpCreateVehicle.Size = new System.Drawing.Size(340, 535);
            grpCreateVehicle.Text = "Create a Vehicle";
            grpCreateVehicle.Name = "grpCreateVehicle";
            // 
            // rdoCar
            // 
            rdoCar.AutoSize = true;
            rdoCar.Location = new System.Drawing.Point(20, 26);
            rdoCar.Text = "Car";
            rdoCar.UseVisualStyleBackColor = true;
            rdoCar.Name = "rdoCar";
            rdoCar.TabIndex = 0;
            rdoCar.Click += RdoCarClickEH;
            // 
            // rdoMotorcycle
            // 
            rdoMotorcycle.AutoSize = true;
            rdoMotorcycle.Location = new System.Drawing.Point(130, 26);
            rdoMotorcycle.Text = "Motorcycle";
            rdoMotorcycle.UseVisualStyleBackColor = true;
            rdoMotorcycle.Name = "rdoMotorcycle";
            rdoMotorcycle.TabIndex = 1;
            rdoMotorcycle.Click += RdoMotorcycleClickEH;
            // 
            // rdoPickup
            // 
            rdoPickup.AutoSize = true;
            rdoPickup.Location = new System.Drawing.Point(20, 52);
            rdoPickup.Text = "Pickup";
            rdoPickup.UseVisualStyleBackColor = true;
            rdoPickup.Name = "rdoPickup";
            rdoPickup.TabIndex = 2;
            rdoPickup.Click += RdoPickupClickEH;
            // 
            // rdoVehicle
            // 
            rdoVehicle.AutoSize = true;
            rdoVehicle.Location = new System.Drawing.Point(130, 52);
            rdoVehicle.Text = "Vehicle";
            rdoVehicle.UseVisualStyleBackColor = true;
            rdoVehicle.Name = "rdoVehicle";
            rdoVehicle.TabIndex = 3;
            rdoVehicle.Click += RdoVehicleClickEH;
            // 
            // lblVehicleTypeError
            // 
            lblVehicleTypeError.AutoSize = true;
            lblVehicleTypeError.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblVehicleTypeError.ForeColor = System.Drawing.Color.Red;
            lblVehicleTypeError.Location = new System.Drawing.Point(20, 78);
            lblVehicleTypeError.Text = "Please Choose a Vehicle Type";
            lblVehicleTypeError.Name = "lblVehicleTypeError";
            // 
            // lblMake
            // 
            lblMake.AutoSize = true;
            lblMake.Location = new System.Drawing.Point(20, 107);
            lblMake.Text = "Make:";
            lblMake.Name = "lblMake";
            // 
            // txtMake
            // 
            txtMake.Location = new System.Drawing.Point(110, 104);
            txtMake.Size = new System.Drawing.Size(160, 23);
            txtMake.Name = "txtMake";
            txtMake.TabIndex = 4;
            txtMake.Leave += TxtMakeLeaveEH;
            // 
            // lblMakeError
            // 
            lblMakeError.AutoSize = true;
            lblMakeError.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblMakeError.ForeColor = System.Drawing.Color.Red;
            lblMakeError.Location = new System.Drawing.Point(110, 129);
            lblMakeError.Text = "Please enter a make";
            lblMakeError.Name = "lblMakeError";
            // 
            // lblModel
            // 
            lblModel.AutoSize = true;
            lblModel.Location = new System.Drawing.Point(20, 162);
            lblModel.Text = "Model:";
            lblModel.Name = "lblModel";
            // 
            // txtModel
            // 
            txtModel.Location = new System.Drawing.Point(110, 159);
            txtModel.Size = new System.Drawing.Size(160, 23);
            txtModel.Name = "txtModel";
            txtModel.TabIndex = 5;
            txtModel.Leave += TxtModelLeaveEH;
            // 
            // lblModelError
            // 
            lblModelError.AutoSize = true;
            lblModelError.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblModelError.ForeColor = System.Drawing.Color.Red;
            lblModelError.Location = new System.Drawing.Point(110, 184);
            lblModelError.Text = "Please enter a model";
            lblModelError.Name = "lblModelError";
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Location = new System.Drawing.Point(20, 217);
            lblYear.Text = "Year:";
            lblYear.Name = "lblYear";
            // 
            // txtYear
            // 
            txtYear.Location = new System.Drawing.Point(110, 214);
            txtYear.Size = new System.Drawing.Size(160, 23);
            txtYear.Name = "txtYear";
            txtYear.TabIndex = 6;
            txtYear.Leave += TxtYearLeaveEH;
            // 
            // lblYearError
            // 
            lblYearError.AutoSize = true;
            lblYearError.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblYearError.ForeColor = System.Drawing.Color.Red;
            lblYearError.Location = new System.Drawing.Point(110, 239);
            lblYearError.Text = "Please enter a valid year";
            lblYearError.Name = "lblYearError";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new System.Drawing.Point(20, 272);
            lblPrice.Text = "Price:";
            lblPrice.Name = "lblPrice";
            // 
            // txtPrice
            // 
            txtPrice.Location = new System.Drawing.Point(110, 269);
            txtPrice.Size = new System.Drawing.Size(160, 23);
            txtPrice.Name = "txtPrice";
            txtPrice.TabIndex = 7;
            txtPrice.Leave += TxtPriceLeaveEH;
            // 
            // lblPriceError
            // 
            lblPriceError.AutoSize = true;
            lblPriceError.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblPriceError.ForeColor = System.Drawing.Color.Red;
            lblPriceError.Location = new System.Drawing.Point(110, 294);
            lblPriceError.Text = "Please enter a valid price";
            lblPriceError.Name = "lblPriceError";
            // 
            // lblWheels
            // 
            lblWheels.AutoSize = true;
            lblWheels.Location = new System.Drawing.Point(20, 327);
            lblWheels.Text = "Wheels:";
            lblWheels.Name = "lblWheels";
            // 
            // txtWheels
            // 
            txtWheels.Location = new System.Drawing.Point(110, 324);
            txtWheels.Size = new System.Drawing.Size(160, 23);
            txtWheels.Name = "txtWheels";
            txtWheels.TabIndex = 8;
            txtWheels.Leave += TxtWheelsLeaveEH;
            // 
            // lblWheelsError
            // 
            lblWheelsError.AutoSize = true;
            lblWheelsError.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblWheelsError.ForeColor = System.Drawing.Color.Red;
            lblWheelsError.Location = new System.Drawing.Point(110, 349);
            lblWheelsError.Text = "Please enter a valid wheel count";
            lblWheelsError.Name = "lblWheelsError";
            // 
            // lblColor
            // 
            lblColor.AutoSize = true;
            lblColor.Location = new System.Drawing.Point(20, 382);
            lblColor.Text = "Color:";
            lblColor.Name = "lblColor";
            // 
            // txtColor
            // 
            txtColor.Location = new System.Drawing.Point(110, 379);
            txtColor.Size = new System.Drawing.Size(160, 23);
            txtColor.Name = "txtColor";
            txtColor.TabIndex = 9;
            txtColor.Leave += TxtColorLeaveEH;
            // 
            // lblColorError
            // 
            lblColorError.AutoSize = true;
            lblColorError.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblColorError.ForeColor = System.Drawing.Color.Red;
            lblColorError.Location = new System.Drawing.Point(110, 404);
            lblColorError.Text = "Please enter a color";
            lblColorError.Name = "lblColorError";
            // 
            // lblMiles
            // 
            lblMiles.AutoSize = true;
            lblMiles.Location = new System.Drawing.Point(20, 437);
            lblMiles.Text = "Miles:";
            lblMiles.Name = "lblMiles";
            // 
            // txtMiles
            // 
            txtMiles.Location = new System.Drawing.Point(110, 434);
            txtMiles.Size = new System.Drawing.Size(160, 23);
            txtMiles.Name = "txtMiles";
            txtMiles.TabIndex = 10;
            txtMiles.Leave += TxtMilesLeaveEH;
            // 
            // lblMilesError
            // 
            lblMilesError.AutoSize = true;
            lblMilesError.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblMilesError.ForeColor = System.Drawing.Color.Red;
            lblMilesError.Location = new System.Drawing.Point(110, 459);
            lblMilesError.Text = "Please enter valid miles";
            lblMilesError.Name = "lblMilesError";
            // 
            // btnCreate
            // 
            btnCreate.Location = new System.Drawing.Point(110, 489);
            btnCreate.Size = new System.Drawing.Size(160, 30);
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Name = "btnCreate";
            btnCreate.TabIndex = 11;
            btnCreate.Click += BtnCreateClickEH;
            // 
            // grpSpecialty
            // 
            grpSpecialty.Controls.Add(lblSpecialtyBoolean);
            grpSpecialty.Controls.Add(rdoSpecialtyYes);
            grpSpecialty.Controls.Add(rdoSpecialtyNo);
            grpSpecialty.Controls.Add(lblSpecialtyBooleanError);
            grpSpecialty.Controls.Add(lblSpecialtyDecimal);
            grpSpecialty.Controls.Add(txtSpecialtyDecimal);
            grpSpecialty.Controls.Add(lblSpecialtyDecimalError);
            grpSpecialty.Location = new System.Drawing.Point(12, 553);
            grpSpecialty.Size = new System.Drawing.Size(340, 170);
            grpSpecialty.Text = "Specialty Properties";
            grpSpecialty.Name = "grpSpecialty";
            // 
            // lblSpecialtyBoolean
            // 
            lblSpecialtyBoolean.AutoSize = true;
            lblSpecialtyBoolean.Location = new System.Drawing.Point(20, 28);
            lblSpecialtyBoolean.Text = "Specialty Boolean:";
            lblSpecialtyBoolean.Name = "lblSpecialtyBoolean";
            // 
            // rdoSpecialtyYes
            // 
            rdoSpecialtyYes.AutoSize = true;
            rdoSpecialtyYes.Location = new System.Drawing.Point(20, 52);
            rdoSpecialtyYes.Text = "Yes";
            rdoSpecialtyYes.UseVisualStyleBackColor = true;
            rdoSpecialtyYes.Name = "rdoSpecialtyYes";
            rdoSpecialtyYes.TabIndex = 12;
            rdoSpecialtyYes.Click += RdoSpecialtyBooleanClickEH;
            // 
            // rdoSpecialtyNo
            // 
            rdoSpecialtyNo.AutoSize = true;
            rdoSpecialtyNo.Location = new System.Drawing.Point(90, 52);
            rdoSpecialtyNo.Text = "No";
            rdoSpecialtyNo.UseVisualStyleBackColor = true;
            rdoSpecialtyNo.Name = "rdoSpecialtyNo";
            rdoSpecialtyNo.TabIndex = 13;
            rdoSpecialtyNo.Click += RdoSpecialtyBooleanClickEH;
            // 
            // lblSpecialtyBooleanError
            // 
            lblSpecialtyBooleanError.AutoSize = true;
            lblSpecialtyBooleanError.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblSpecialtyBooleanError.ForeColor = System.Drawing.Color.Red;
            lblSpecialtyBooleanError.Location = new System.Drawing.Point(20, 78);
            lblSpecialtyBooleanError.Text = "Please select Yes or No";
            lblSpecialtyBooleanError.Name = "lblSpecialtyBooleanError";
            // 
            // lblSpecialtyDecimal
            // 
            lblSpecialtyDecimal.AutoSize = true;
            lblSpecialtyDecimal.Location = new System.Drawing.Point(20, 106);
            lblSpecialtyDecimal.Text = "Specialty Decimal:";
            lblSpecialtyDecimal.Name = "lblSpecialtyDecimal";
            // 
            // txtSpecialtyDecimal
            // 
            txtSpecialtyDecimal.Location = new System.Drawing.Point(170, 103);
            txtSpecialtyDecimal.Size = new System.Drawing.Size(150, 23);
            txtSpecialtyDecimal.Name = "txtSpecialtyDecimal";
            txtSpecialtyDecimal.TabIndex = 14;
            txtSpecialtyDecimal.Leave += TxtSpecialtyDecimalLeaveEH;
            // 
            // lblSpecialtyDecimalError
            // 
            lblSpecialtyDecimalError.AutoSize = true;
            lblSpecialtyDecimalError.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblSpecialtyDecimalError.ForeColor = System.Drawing.Color.Red;
            lblSpecialtyDecimalError.Location = new System.Drawing.Point(20, 134);
            lblSpecialtyDecimalError.Text = "Please enter a valid number";
            lblSpecialtyDecimalError.Name = "lblSpecialtyDecimalError";
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new System.Drawing.Point(370, 20);
            lblSearch.Text = "Search (make, model, or year):";
            lblSearch.Name = "lblSearch";
            // 
            // txtSearch
            // 
            txtSearch.Location = new System.Drawing.Point(560, 16);
            txtSearch.Size = new System.Drawing.Size(190, 23);
            txtSearch.Name = "txtSearch";
            txtSearch.TabIndex = 15;
            // 
            // btnSearch
            // 
            btnSearch.Location = new System.Drawing.Point(758, 14);
            btnSearch.Size = new System.Drawing.Size(80, 28);
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Name = "btnSearch";
            btnSearch.TabIndex = 16;
            btnSearch.Click += BtnSearchClickEH;
            // 
            // btnClearSearch
            // 
            btnClearSearch.Location = new System.Drawing.Point(844, 14);
            btnClearSearch.Size = new System.Drawing.Size(80, 28);
            btnClearSearch.Text = "Show All";
            btnClearSearch.UseVisualStyleBackColor = true;
            btnClearSearch.Name = "btnClearSearch";
            btnClearSearch.TabIndex = 17;
            btnClearSearch.Click += BtnClearSearchClickEH;
            // 
            // lblSort
            // 
            lblSort.AutoSize = true;
            lblSort.Location = new System.Drawing.Point(370, 56);
            lblSort.Text = "Sort by:";
            lblSort.Name = "lblSort";
            // 
            // cmbSort
            // 
            cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbSort.FormattingEnabled = true;
            cmbSort.Items.AddRange(new object[] { "Price", "Year", "Make/Model" });
            cmbSort.Location = new System.Drawing.Point(430, 52);
            cmbSort.Size = new System.Drawing.Size(130, 23);
            cmbSort.Name = "cmbSort";
            cmbSort.TabIndex = 18;
            // 
            // btnSort
            // 
            btnSort.Location = new System.Drawing.Point(568, 50);
            btnSort.Size = new System.Drawing.Size(80, 28);
            btnSort.Text = "Sort";
            btnSort.UseVisualStyleBackColor = true;
            btnSort.Name = "btnSort";
            btnSort.TabIndex = 19;
            btnSort.Click += BtnSortClickEH;
            // 
            // btnSaveInventory
            // 
            btnSaveInventory.Location = new System.Drawing.Point(934, 14);
            btnSaveInventory.Size = new System.Drawing.Size(130, 28);
            btnSaveInventory.Text = "Save Inventory";
            btnSaveInventory.UseVisualStyleBackColor = true;
            btnSaveInventory.Name = "btnSaveInventory";
            btnSaveInventory.TabIndex = 20;
            btnSaveInventory.Click += BtnSaveInventoryClickEH;
            // 
            // btnLoadInventory
            // 
            btnLoadInventory.Location = new System.Drawing.Point(934, 50);
            btnLoadInventory.Size = new System.Drawing.Size(130, 28);
            btnLoadInventory.Text = "Load Inventory";
            btnLoadInventory.UseVisualStyleBackColor = true;
            btnLoadInventory.Name = "btnLoadInventory";
            btnLoadInventory.TabIndex = 21;
            btnLoadInventory.Click += BtnLoadInventoryClickEH;
            // 
            // grpInventory
            // 
            grpInventory.Controls.Add(lstInventory);
            grpInventory.Location = new System.Drawing.Point(370, 88);
            grpInventory.Size = new System.Drawing.Size(700, 270);
            grpInventory.Text = "Store Inventory";
            grpInventory.Name = "grpInventory";
            // 
            // lstInventory
            // 
            lstInventory.FormattingEnabled = true;
            lstInventory.HorizontalScrollbar = true;
            lstInventory.ItemHeight = 15;
            lstInventory.Location = new System.Drawing.Point(10, 22);
            lstInventory.Size = new System.Drawing.Size(680, 240);
            lstInventory.Name = "lstInventory";
            lstInventory.TabIndex = 22;
            // 
            // btnAddToCart
            // 
            btnAddToCart.Location = new System.Drawing.Point(370, 366);
            btnAddToCart.Size = new System.Drawing.Size(150, 32);
            btnAddToCart.Text = "Add to Cart";
            btnAddToCart.UseVisualStyleBackColor = true;
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.TabIndex = 23;
            btnAddToCart.Click += BtnAddToCartClickEH;
            // 
            // btnRemoveFromCart
            // 
            btnRemoveFromCart.Location = new System.Drawing.Point(530, 366);
            btnRemoveFromCart.Size = new System.Drawing.Size(170, 32);
            btnRemoveFromCart.Text = "Remove from Cart";
            btnRemoveFromCart.UseVisualStyleBackColor = true;
            btnRemoveFromCart.Name = "btnRemoveFromCart";
            btnRemoveFromCart.TabIndex = 24;
            btnRemoveFromCart.Click += BtnRemoveFromCartClickEH;
            // 
            // grpShoppingCart
            // 
            grpShoppingCart.Controls.Add(lstShoppingCart);
            grpShoppingCart.Location = new System.Drawing.Point(370, 406);
            grpShoppingCart.Size = new System.Drawing.Size(700, 240);
            grpShoppingCart.Text = "Shopping Cart";
            grpShoppingCart.Name = "grpShoppingCart";
            // 
            // lstShoppingCart
            // 
            lstShoppingCart.FormattingEnabled = true;
            lstShoppingCart.HorizontalScrollbar = true;
            lstShoppingCart.ItemHeight = 15;
            lstShoppingCart.Location = new System.Drawing.Point(10, 22);
            lstShoppingCart.Size = new System.Drawing.Size(680, 210);
            lstShoppingCart.Name = "lstShoppingCart";
            lstShoppingCart.TabIndex = 25;
            // 
            // btnCheckout
            // 
            btnCheckout.Location = new System.Drawing.Point(370, 656);
            btnCheckout.Size = new System.Drawing.Size(150, 32);
            btnCheckout.Text = "Checkout";
            btnCheckout.UseVisualStyleBackColor = true;
            btnCheckout.Name = "btnCheckout";
            btnCheckout.TabIndex = 26;
            btnCheckout.Click += BtnCheckoutClickEH;
            // 
            // lblTotalText
            // 
            lblTotalText.AutoSize = true;
            lblTotalText.Location = new System.Drawing.Point(540, 664);
            lblTotalText.Text = "Total:";
            lblTotalText.Name = "lblTotalText";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblTotal.Location = new System.Drawing.Point(590, 664);
            lblTotal.Text = "$0";
            lblTotal.Name = "lblTotal";
            // 
            // FrmVehicleStore
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1084, 735);
            Controls.Add(grpCreateVehicle);
            Controls.Add(grpSpecialty);
            Controls.Add(lblSearch);
            Controls.Add(txtSearch);
            Controls.Add(btnSearch);
            Controls.Add(btnClearSearch);
            Controls.Add(lblSort);
            Controls.Add(cmbSort);
            Controls.Add(btnSort);
            Controls.Add(btnSaveInventory);
            Controls.Add(btnLoadInventory);
            Controls.Add(grpInventory);
            Controls.Add(btnAddToCart);
            Controls.Add(btnRemoveFromCart);
            Controls.Add(grpShoppingCart);
            Controls.Add(btnCheckout);
            Controls.Add(lblTotalText);
            Controls.Add(lblTotal);
            Name = "FrmVehicleStore";
            Text = "Vehicle Store";
            grpCreateVehicle.ResumeLayout(false);
            grpCreateVehicle.PerformLayout();
            grpSpecialty.ResumeLayout(false);
            grpSpecialty.PerformLayout();
            grpInventory.ResumeLayout(false);
            grpInventory.PerformLayout();
            grpShoppingCart.ResumeLayout(false);
            grpShoppingCart.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox grpCreateVehicle;
        private System.Windows.Forms.RadioButton rdoCar;
        private System.Windows.Forms.RadioButton rdoMotorcycle;
        private System.Windows.Forms.RadioButton rdoPickup;
        private System.Windows.Forms.RadioButton rdoVehicle;
        private System.Windows.Forms.Label lblVehicleTypeError;
        private System.Windows.Forms.Label lblMake;
        private System.Windows.Forms.TextBox txtMake;
        private System.Windows.Forms.Label lblMakeError;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label lblModelError;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label lblYearError;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblPriceError;
        private System.Windows.Forms.Label lblWheels;
        private System.Windows.Forms.TextBox txtWheels;
        private System.Windows.Forms.Label lblWheelsError;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label lblColorError;
        private System.Windows.Forms.Label lblMiles;
        private System.Windows.Forms.TextBox txtMiles;
        private System.Windows.Forms.Label lblMilesError;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.GroupBox grpSpecialty;
        private System.Windows.Forms.Label lblSpecialtyBoolean;
        private System.Windows.Forms.RadioButton rdoSpecialtyYes;
        private System.Windows.Forms.RadioButton rdoSpecialtyNo;
        private System.Windows.Forms.Label lblSpecialtyBooleanError;
        private System.Windows.Forms.Label lblSpecialtyDecimal;
        private System.Windows.Forms.TextBox txtSpecialtyDecimal;
        private System.Windows.Forms.Label lblSpecialtyDecimalError;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.Label lblSort;
        private System.Windows.Forms.ComboBox cmbSort;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Button btnSaveInventory;
        private System.Windows.Forms.Button btnLoadInventory;
        private System.Windows.Forms.GroupBox grpInventory;
        private System.Windows.Forms.ListBox lstInventory;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.Button btnRemoveFromCart;
        private System.Windows.Forms.GroupBox grpShoppingCart;
        private System.Windows.Forms.ListBox lstShoppingCart;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Label lblTotalText;
        private System.Windows.Forms.Label lblTotal;
    }
}
