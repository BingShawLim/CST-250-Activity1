/*
 * Bing [Last Name]
 * CST-250
 * 10/25/2026
 * Vehicle Store GUI App
 * Activity 1
 * Resources: CST-250 Activity 1 Guide (Grand Canyon University, 2025);
 *   Microsoft Learn - BindingSource Class, Comparison<T> Delegate
 */

using VehicleClassLibrary.Models;
using VehicleClassLibrary.Services.BusinessLogicLayer;

namespace VehicleStoreGUIApp
{
    /// <summary>
    /// Windows Forms presentation layer for the vehicle store. Collects and validates user
    /// input, then hands all data work to the StoreLogic business logic layer.
    /// </summary>
    public partial class FrmVehicleStore : Form
    {
        // Class level variables
        string currentVehicleType;
        // Validation flags (one per user input)
        bool isVehicleTypeValid = false, isMakeValid = false, isModelValid = false,
            isYearValid = false, isPriceValid = false, isWheelsValid = false,
            isColorValid = false, isMilesValid = false,
            isSpecialtyBooleanValid = false, isSpecialtyDecimalValid = false;
        // Create a new vehicle store logic variable
        private StoreLogic _storeLogic;
        // Binding sources for inventory and shopping cart
        private BindingSource _inventoryBindingSource;
        private BindingSource _shoppingCartBindingSource;

        /// <summary>
        /// Default constructor for FrmVehicleStore
        /// </summary>
        public FrmVehicleStore()
        {
            InitializeComponent();
            // Initialize the current vehicle to create
            currentVehicleType = "";
            // Hide the error labels
            lblVehicleTypeError.Visible = false;
            lblMakeError.Visible = false;
            lblModelError.Visible = false;
            lblYearError.Visible = false;
            lblPriceError.Visible = false;
            lblWheelsError.Visible = false;
            lblColorError.Visible = false;
            lblMilesError.Visible = false;
            lblSpecialtyBooleanError.Visible = false;
            lblSpecialtyDecimalError.Visible = false;
            // Initialize the store logic variable
            _storeLogic = new StoreLogic();

            // Initialize the binding source variables
            _inventoryBindingSource = new BindingSource();
            _shoppingCartBindingSource = new BindingSource();
            // Set the data sources of the binding source objects
            _inventoryBindingSource.DataSource = _storeLogic.GetInventory();
            _shoppingCartBindingSource.DataSource = _storeLogic.GetShoppingCart();
            // Set the data source for each list control
            lstInventory.DataSource = _inventoryBindingSource;
            lstShoppingCart.DataSource = _shoppingCartBindingSource;
            // Default the sort drop-down to the first option
            cmbSort.SelectedIndex = 0;
        }

        /// <summary>
        /// Click event handler to create a car
        /// </summary>
        /// <param name="sender">The car radio button</param>
        /// <param name="e">Event arguments</param>
        private void RdoCarClickEH(object sender, EventArgs e)
        {
            // Update the selected vehicle variable
            currentVehicleType = "Car";

            // Change the label for the specialty boolean
            lblSpecialtyBoolean.Text = "Is the car a convertible?";
            // Change the label for the specialty decimal
            lblSpecialtyDecimal.Text = "Trunk Size (cubic feet):";

            // Show the specialty controls
            ShowSpecialtyControls(true);
            // Validate the vehicle type
            ValidateVehicleType();
        }

        /// <summary>
        /// Click event handler to create a motorcycle
        /// </summary>
        /// <param name="sender">The motorcycle radio button</param>
        /// <param name="e">Event arguments</param>
        private void RdoMotorcycleClickEH(object sender, EventArgs e)
        {
            // Update the selected vehicle variable
            currentVehicleType = "Motorcycle";

            // Change the label for the specialty boolean
            lblSpecialtyBoolean.Text = "Does it have a side car?";
            // Change the label for the specialty decimal
            lblSpecialtyDecimal.Text = "Seat Height (inches):";

            // Show the specialty controls
            ShowSpecialtyControls(true);
            // Validate the vehicle type
            ValidateVehicleType();
        }

        /// <summary>
        /// Click event handler to create a pickup
        /// </summary>
        /// <param name="sender">The pickup radio button</param>
        /// <param name="e">Event arguments</param>
        private void RdoPickupClickEH(object sender, EventArgs e)
        {
            // Update the selected vehicle variable
            currentVehicleType = "Pickup";

            // Change the label for the specialty boolean
            lblSpecialtyBoolean.Text = "Does it have a bed cover?";
            // Change the label for the specialty decimal
            lblSpecialtyDecimal.Text = "Bed Size (cubic feet):";

            // Show the specialty controls
            ShowSpecialtyControls(true);
            // Validate the vehicle type
            ValidateVehicleType();
        }

        /// <summary>
        /// Click event handler to create a standard vehicle
        /// </summary>
        /// <param name="sender">The vehicle radio button</param>
        /// <param name="e">Event arguments</param>
        private void RdoVehicleClickEH(object sender, EventArgs e)
        {
            // Update the selected vehicle variable
            currentVehicleType = "Vehicle";

            // A standard vehicle has no specialty properties, so hide them
            ShowSpecialtyControls(false);
            lblSpecialtyBooleanError.Visible = false;
            lblSpecialtyDecimalError.Visible = false;
            // Validate the vehicle type
            ValidateVehicleType();
        }

        /// <summary>
        /// Show or hide the specialty boolean and decimal controls
        /// </summary>
        /// <param name="isVisible">True to show the controls</param>
        private void ShowSpecialtyControls(bool isVisible)
        {
            // Show the specialty boolean label and radio buttons
            lblSpecialtyBoolean.Visible = isVisible;
            rdoSpecialtyYes.Visible = isVisible;
            rdoSpecialtyNo.Visible = isVisible;
            // Show the specialty decimal label and text box
            lblSpecialtyDecimal.Visible = isVisible;
            txtSpecialtyDecimal.Visible = isVisible;
        }

        /// <summary>
        /// Click event handler for the Create button. Validates every input and adds the vehicle.
        /// </summary>
        /// <param name="sender">The create button</param>
        /// <param name="e">Event arguments</param>
        private void BtnCreateClickEH(object sender, EventArgs e)
        {
            // Declare and initialize
            string make = "", model = "", color = "";
            int year = 0, wheels = 0, miles = 0, id = 0;
            decimal price = 0m, specialtyDecimal = 0m;
            bool specialtyBoolean = false;
            VehicleModel vehicle;

            // Read and validate the user entered data
            ValidateVehicleType();
            make = ValidateTxtMake();
            model = ValidateTxtModel();
            year = ValidateTxtYear();
            price = ValidateTxtPrice();
            wheels = ValidateTxtWheels();
            color = ValidateTxtColor();
            miles = ValidateTxtMiles();
            specialtyBoolean = ValidateSpecialtyBoolean();
            specialtyDecimal = ValidateSpecialtyDecimal();

            // Check the state of the flags
            if (isVehicleTypeValid && isMakeValid && isModelValid && isYearValid && isPriceValid &&
                isWheelsValid && isColorValid && isMilesValid && isSpecialtyBooleanValid &&
                isSpecialtyDecimalValid)
            {
                switch (currentVehicleType)
                {
                    case "Car":
                        // Create a new car
                        vehicle = new CarModel(id, make, model, year, price, wheels, color, miles,
                            specialtyBoolean, specialtyDecimal);
                        break;

                    case "Motorcycle":
                        // Create a new motorcycle
                        vehicle = new MotorcycleModel(id, make, model, year, price, wheels, color, miles,
                            specialtyBoolean, specialtyDecimal);
                        break;

                    case "Pickup":
                        // Create a new pickup
                        vehicle = new PickupModel(id, make, model, year, price, wheels, color, miles,
                            specialtyBoolean, specialtyDecimal);
                        break;

                    default:
                        // Create a new vehicle
                        vehicle = new VehicleModel(id, make, model, year, price, wheels, color, miles);
                        break;
                }

                // GUI Challenge 6: block a vehicle identical to one already in the inventory
                if (_storeLogic.IsDuplicate(vehicle))
                {
                    MessageBox.Show("An identical vehicle is already in the inventory.", "Duplicate Vehicle",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Add the vehicle to the inventory
                _storeLogic.AddVehicleToInventory(vehicle);
                // Show the user a success message
                MessageBox.Show($"The following vehicle has been added to the inventory:\n{vehicle}");

                // Clear the input fields
                ClearInputFields();
                // Refresh the inventory list control (false = the item type has not changed)
                _inventoryBindingSource.ResetBindings(false);
            }
        }

        /// <summary>
        /// Clear every input control after a vehicle is created
        /// </summary>
        private void ClearInputFields()
        {
            // Clear the radio buttons and text boxes
            rdoCar.Checked = false;
            rdoMotorcycle.Checked = false;
            rdoPickup.Checked = false;
            rdoVehicle.Checked = false;
            txtMake.Clear();
            txtModel.Clear();
            txtYear.Clear();
            txtPrice.Clear();
            txtWheels.Clear();
            txtColor.Clear();
            txtMiles.Clear();
            rdoSpecialtyYes.Checked = false;
            rdoSpecialtyNo.Checked = false;
            txtSpecialtyDecimal.Clear();
            // Reset the selected vehicle type
            currentVehicleType = "";
        }

        /// <summary>
        /// Validate that a vehicle type radio button is selected
        /// </summary>
        private void ValidateVehicleType()
        {
            // Make sure one of the four vehicle types is checked
            if (!rdoCar.Checked && !rdoMotorcycle.Checked && !rdoPickup.Checked && !rdoVehicle.Checked)
            {
                lblVehicleTypeError.Visible = true;
                // Set the flag
                isVehicleTypeValid = false;
            }
            else
            {
                lblVehicleTypeError.Visible = false;
                // Clear the flag
                isVehicleTypeValid = true;
            }
        }

        /// <summary>
        /// Validate the make textbox
        /// </summary>
        /// <returns>The text from the make textbox</returns>
        private string ValidateTxtMake()
        {
            // Test for a null/empty textbox
            if (string.IsNullOrEmpty(txtMake.Text))
            {
                lblMakeError.Visible = true;
                // Set the flag
                isMakeValid = false;
            }
            else
            {
                lblMakeError.Visible = false;
                // Clear the flag
                isMakeValid = true;
            }
            // Return the text from the textbox
            return txtMake.Text;
        }

        /// <summary>
        /// Validate the model textbox
        /// </summary>
        /// <returns>The text from the model textbox</returns>
        private string ValidateTxtModel()
        {
            // Test for a null/empty textbox
            if (string.IsNullOrEmpty(txtModel.Text))
            {
                lblModelError.Visible = true;
                // Set the flag
                isModelValid = false;
            }
            else
            {
                lblModelError.Visible = false;
                // Clear the flag
                isModelValid = true;
            }
            // Return the text from the textbox
            return txtModel.Text;
        }

        /// <summary>
        /// Validate the year textbox
        /// </summary>
        /// <returns>The parsed year, or 0 if the input is invalid</returns>
        private int ValidateTxtYear()
        {
            // Declare and initialize
            int year = 0;
            // Test for an empty textbox or text that is not a whole number
            if (string.IsNullOrEmpty(txtYear.Text) || !int.TryParse(txtYear.Text, out year) ||
                year < 1886 || year > DateTime.Now.Year + 1)
            {
                lblYearError.Visible = true;
                // Set the flag
                isYearValid = false;
            }
            else
            {
                lblYearError.Visible = false;
                // Clear the flag
                isYearValid = true;
            }
            // Return the parsed year
            return year;
        }

        /// <summary>
        /// Validate the price textbox
        /// </summary>
        /// <returns>The parsed price, or 0 if the input is invalid</returns>
        private decimal ValidateTxtPrice()
        {
            // Declare and initialize
            decimal price = 0m;
            // Test for an empty textbox or text that is not a non-negative number
            if (string.IsNullOrEmpty(txtPrice.Text) || !decimal.TryParse(txtPrice.Text, out price) || price < 0)
            {
                lblPriceError.Visible = true;
                // Set the flag
                isPriceValid = false;
            }
            else
            {
                lblPriceError.Visible = false;
                // Clear the flag
                isPriceValid = true;
            }
            // Return the parsed price
            return price;
        }

        /// <summary>
        /// Validate the number of wheels textbox
        /// </summary>
        /// <returns>The parsed wheel count, or 0 if the input is invalid</returns>
        private int ValidateTxtWheels()
        {
            // Declare and initialize
            int wheels = 0;
            // Test for an empty textbox or text that is not a positive whole number
            if (string.IsNullOrEmpty(txtWheels.Text) || !int.TryParse(txtWheels.Text, out wheels) || wheels < 1)
            {
                lblWheelsError.Visible = true;
                // Set the flag
                isWheelsValid = false;
            }
            else
            {
                lblWheelsError.Visible = false;
                // Clear the flag
                isWheelsValid = true;
            }
            // Return the parsed wheel count
            return wheels;
        }

        /// <summary>
        /// Validate the color textbox (GUI Challenge 1)
        /// </summary>
        /// <returns>The text from the color textbox</returns>
        private string ValidateTxtColor()
        {
            // Test for a null/empty textbox
            if (string.IsNullOrEmpty(txtColor.Text))
            {
                lblColorError.Visible = true;
                // Set the flag
                isColorValid = false;
            }
            else
            {
                lblColorError.Visible = false;
                // Clear the flag
                isColorValid = true;
            }
            // Return the text from the textbox
            return txtColor.Text;
        }

        /// <summary>
        /// Validate the miles textbox (GUI Challenge 1)
        /// </summary>
        /// <returns>The parsed miles, or 0 if the input is invalid</returns>
        private int ValidateTxtMiles()
        {
            // Declare and initialize
            int miles = 0;
            // Test for an empty textbox or text that is not a non-negative whole number
            if (string.IsNullOrEmpty(txtMiles.Text) || !int.TryParse(txtMiles.Text, out miles) || miles < 0)
            {
                lblMilesError.Visible = true;
                // Set the flag
                isMilesValid = false;
            }
            else
            {
                lblMilesError.Visible = false;
                // Clear the flag
                isMilesValid = true;
            }
            // Return the parsed miles
            return miles;
        }

        /// <summary>
        /// Validate that Yes or No is selected for the specialty boolean
        /// </summary>
        /// <returns>True when Yes is checked, otherwise false</returns>
        private bool ValidateSpecialtyBoolean()
        {
            // A standard vehicle has no specialty boolean
            if (currentVehicleType == "Vehicle")
            {
                lblSpecialtyBooleanError.Visible = false;
                isSpecialtyBooleanValid = true;
            }
            // Make sure Yes or No is selected
            else if (rdoSpecialtyYes.Checked || rdoSpecialtyNo.Checked)
            {
                lblSpecialtyBooleanError.Visible = false;
                isSpecialtyBooleanValid = true;
            }
            else
            {
                lblSpecialtyBooleanError.Visible = true;
                isSpecialtyBooleanValid = false;
            }
            // When Yes is not checked we assume No is checked
            return rdoSpecialtyYes.Checked;
        }

        /// <summary>
        /// Validate the specialty decimal textbox
        /// </summary>
        /// <returns>The parsed specialty decimal, or 0 if the input is invalid</returns>
        private decimal ValidateSpecialtyDecimal()
        {
            // Declare and initialize
            decimal specialtyDecimal = 0m;
            // Only cars, motorcycles, and pickups have a specialty decimal
            if (currentVehicleType != "Vehicle")
            {
                // Test for an empty textbox or text that is not a non-negative number
                if (string.IsNullOrEmpty(txtSpecialtyDecimal.Text) ||
                    !decimal.TryParse(txtSpecialtyDecimal.Text, out specialtyDecimal) || specialtyDecimal < 0)
                {
                    lblSpecialtyDecimalError.Visible = true;
                    isSpecialtyDecimalValid = false;
                }
                else
                {
                    lblSpecialtyDecimalError.Visible = false;
                    isSpecialtyDecimalValid = true;
                }
            }
            else
            {
                // A standard vehicle does not need a specialty decimal
                lblSpecialtyDecimalError.Visible = false;
                isSpecialtyDecimalValid = true;
            }
            // Return the parsed specialty decimal
            return specialtyDecimal;
        }

        /// <summary>
        /// Leave event handler to validate the make as soon as the user leaves the textbox
        /// </summary>
        /// <param name="sender">The make textbox</param>
        /// <param name="e">Event arguments</param>
        private void TxtMakeLeaveEH(object sender, EventArgs e)
        {
            ValidateTxtMake();
        }

        /// <summary>
        /// Leave event handler to validate the model
        /// </summary>
        /// <param name="sender">The model textbox</param>
        /// <param name="e">Event arguments</param>
        private void TxtModelLeaveEH(object sender, EventArgs e)
        {
            ValidateTxtModel();
        }

        /// <summary>
        /// Leave event handler to validate the year
        /// </summary>
        /// <param name="sender">The year textbox</param>
        /// <param name="e">Event arguments</param>
        private void TxtYearLeaveEH(object sender, EventArgs e)
        {
            ValidateTxtYear();
        }

        /// <summary>
        /// Leave event handler to validate the price
        /// </summary>
        /// <param name="sender">The price textbox</param>
        /// <param name="e">Event arguments</param>
        private void TxtPriceLeaveEH(object sender, EventArgs e)
        {
            ValidateTxtPrice();
        }

        /// <summary>
        /// Leave event handler to validate the number of wheels
        /// </summary>
        /// <param name="sender">The wheels textbox</param>
        /// <param name="e">Event arguments</param>
        private void TxtWheelsLeaveEH(object sender, EventArgs e)
        {
            ValidateTxtWheels();
        }

        /// <summary>
        /// Leave event handler to validate the color (GUI Challenge 1)
        /// </summary>
        /// <param name="sender">The color textbox</param>
        /// <param name="e">Event arguments</param>
        private void TxtColorLeaveEH(object sender, EventArgs e)
        {
            ValidateTxtColor();
        }

        /// <summary>
        /// Leave event handler to validate the miles (GUI Challenge 1)
        /// </summary>
        /// <param name="sender">The miles textbox</param>
        /// <param name="e">Event arguments</param>
        private void TxtMilesLeaveEH(object sender, EventArgs e)
        {
            ValidateTxtMiles();
        }

        /// <summary>
        /// Leave event handler to validate the specialty decimal
        /// </summary>
        /// <param name="sender">The specialty decimal textbox</param>
        /// <param name="e">Event arguments</param>
        private void TxtSpecialtyDecimalLeaveEH(object sender, EventArgs e)
        {
            ValidateSpecialtyDecimal();
        }

        /// <summary>
        /// Click event handler shared by the Yes and No radio buttons
        /// </summary>
        /// <param name="sender">The Yes or No radio button</param>
        /// <param name="e">Event arguments</param>
        private void RdoSpecialtyBooleanClickEH(object sender, EventArgs e)
        {
            ValidateSpecialtyBoolean();
        }

        /// <summary>
        /// Click event handler to add the selected inventory vehicle to the shopping cart
        /// </summary>
        /// <param name="sender">The Add to Cart button</param>
        /// <param name="e">Event arguments</param>
        private void BtnAddToCartClickEH(object sender, EventArgs e)
        {
            // Make sure a vehicle is selected
            if (lstInventory.SelectedItem is VehicleModel vehicle)
            {
                // Send the vehicle's id to the business logic layer
                _storeLogic.AddVehicleToCart(vehicle.Id);
                // Refresh the shopping cart list control
                _shoppingCartBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Please select a vehicle from the inventory first.");
            }
        }

        /// <summary>
        /// Click event handler to remove the selected vehicle from the shopping cart (GUI Challenge 3)
        /// </summary>
        /// <param name="sender">The Remove from Cart button</param>
        /// <param name="e">Event arguments</param>
        private void BtnRemoveFromCartClickEH(object sender, EventArgs e)
        {
            // Make sure a cart item is selected
            if (lstShoppingCart.SelectedIndex >= 0)
            {
                // Remove by position so only the selected copy is removed
                _storeLogic.RemoveVehicleFromCart(lstShoppingCart.SelectedIndex);
                // Refresh the shopping cart list control
                _shoppingCartBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Please select a vehicle in the shopping cart to remove.");
            }
        }

        /// <summary>
        /// Click event handler to check out and show the total
        /// </summary>
        /// <param name="sender">The Checkout button</param>
        /// <param name="e">Event arguments</param>
        private void BtnCheckoutClickEH(object sender, EventArgs e)
        {
            // Declare and initialize
            decimal total = 0m;
            // Check out through the business logic layer
            total = _storeLogic.Checkout();
            // Show the formatted total
            lblTotal.Text = total.ToString("C");
            // Refresh the now empty shopping cart list control
            _shoppingCartBindingSource.ResetBindings(false);
        }

        /// <summary>
        /// Click event handler to filter the inventory list (GUI Challenge 2)
        /// </summary>
        /// <param name="sender">The Search button</param>
        /// <param name="e">Event arguments</param>
        private void BtnSearchClickEH(object sender, EventArgs e)
        {
            // Show only the vehicles that match the search text
            _inventoryBindingSource.DataSource = _storeLogic.SearchInventory(txtSearch.Text);
            _inventoryBindingSource.ResetBindings(false);
        }

        /// <summary>
        /// Click event handler to clear the search and show the full inventory (GUI Challenge 2)
        /// </summary>
        /// <param name="sender">The Show All button</param>
        /// <param name="e">Event arguments</param>
        private void BtnClearSearchClickEH(object sender, EventArgs e)
        {
            // Point the list back at the full inventory
            txtSearch.Clear();
            _inventoryBindingSource.DataSource = _storeLogic.GetInventory();
            _inventoryBindingSource.ResetBindings(false);
        }

        /// <summary>
        /// Click event handler to sort the inventory (GUI Challenge 4)
        /// </summary>
        /// <param name="sender">The Sort button</param>
        /// <param name="e">Event arguments</param>
        private void BtnSortClickEH(object sender, EventArgs e)
        {
            // Sort by the option chosen in the drop-down
            string sortBy = cmbSort.SelectedItem?.ToString() ?? "Price";
            _storeLogic.SortInventory(sortBy);
            // Show the full, sorted inventory
            _inventoryBindingSource.DataSource = _storeLogic.GetInventory();
            _inventoryBindingSource.ResetBindings(false);
        }

        /// <summary>
        /// Click event handler to save the inventory to the text file (GUI Challenge 5)
        /// </summary>
        /// <param name="sender">The Save Inventory button</param>
        /// <param name="e">Event arguments</param>
        private void BtnSaveInventoryClickEH(object sender, EventArgs e)
        {
            // Write the inventory and tell the user how it went
            if (_storeLogic.WriteInventory())
            {
                MessageBox.Show("The inventory has been saved to the text file.");
            }
            else
            {
                MessageBox.Show("The inventory could not be saved.");
            }
        }

        /// <summary>
        /// Click event handler to load the inventory from the text file (GUI Challenge 5)
        /// </summary>
        /// <param name="sender">The Load Inventory button</param>
        /// <param name="e">Event arguments</param>
        private void BtnLoadInventoryClickEH(object sender, EventArgs e)
        {
            // Read the file into the inventory and refresh the list control
            _storeLogic.ReadInventory();
            _inventoryBindingSource.DataSource = _storeLogic.GetInventory();
            _inventoryBindingSource.ResetBindings(false);
            MessageBox.Show("The inventory has been loaded from the text file.");
        }
    }
}
