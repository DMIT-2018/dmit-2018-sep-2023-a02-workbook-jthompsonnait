
using HogWildWeb.Areas.ViewModels;
using Microsoft.AspNetCore.Components;

namespace HogWildWeb.Pages.SamplePages
{
    public partial class Basics
    {
        #region Privates

        // used to display my name
        private string? myName;

        // the odd or even value
        private int oddEvenValue;

        #region Text Boxes
        //  email address
        private string emailText;
        //  password
        private string passwordText;
        //  data
        private DateTime? dateText = DateTime.Today;
        #endregion

        #region Radio Buttons, Check Boxes & Text area
        //  selected meal
        private string meal = "breakfast";
        private string[] meals { get; set; } = new string[] { "breakfast", "lunch", "dinner", "snacks" };
        //  used to hold the value of the acceptance
        private bool acceptanceBox;
        //  used to hold the value for the message body
        private string messageBody;
        #endregion

        #region List and Sliders
        //  pretend that the following collection is data from a database
        //  The collection is based on a property class called SelectionList
        //  The data for the list will be created in a separate method.
        /// <summary>
        /// Get or sets a list of SelectionView object representing various rides
        /// </summary>
        private List<SelectionView> rides;

        /// <summary>
        /// Get or set the ID of the selection ride from the rides list
        /// </summary>
        private int myRide;

        /// <summary>
        /// Get or set the user's choice vacation spot as a string
        /// </summary>
        private string vacationSpot;

        /// <summary>
        /// Get or sets a list of strings representing various vacation spots
        /// </summary>
        private List<string> vacationSpots;

        /// <summary>
        /// Gets or sets the review rating.
        /// </summary>
        /// <value>The review rating.</value>
        private int reviewRating = 5;
        #endregion
        //  used to display any feedback to the end user.
        private string feedback;

 #endregion

        #region Methods

        //  This method is automatically called when the component is initialized
        protected override async Task OnInitializedAsync()
        {
            //  Call the base class OnInitializedAsync method (if any)
            await base.OnInitializedAsync();

            //  call the randomValue method to perform custom initialization logic.
            RandomValue();

            //  Call the 'PopulatedList' method to populate predefined data for the list
            PopulatedList();
        }

        //  Generates a random number between 0 and 25 using the Random class
        //  Checks if the generated number is even
        //  Sets the 'myName' variable to a message if even, or tp null if oddd
        private void RandomValue()
        {
            //  Create an instance of the Random class to generate random numbers
            Random rnd = new Random();

            //  Generate a random integer between 0 (inclusive) and 25 (exclusive)
            oddEvenValue = rnd.Next(0, 25);

            //  Check if the generated number is even.
            if (oddEvenValue % 2 == 0)
            {
                //  if the number is even, construct a msessage with the number and assign it to myName
                myName = $"James is even {oddEvenValue}";
            }
            else
            {
                //  if the number is odd, set myName to null
                myName = null;
            }

            //  trigger an asynchronous update of the component's state to reflect the changes made.
            InvokeAsync(StateHasChanged);
        }

        //  This method is called when a user submits text input.
        private void TextSubmit()
        {
            //  Combine the values of emailtext, passwordText , and dateText into a feedback message.
            feedback = $"Email {emailText}; Password {passwordText}; Date {dateText}";

            //  Trigger a re-render of the component to reflect the updated feedback.
            InvokeAsync(StateHasChanged);
        }

        //  Handle the selction of the meal
        private void HandMealSelection(ChangeEventArgs e)
        {
            meal = e.Value.ToString();
        }

        //  This method is called when a user submits radio, check box and area text
        private void RadioCheckAreaSubmit()
        {
            //  Combine various values and store them in the 'feedback' variable as a formatted string.
            feedback = $"Meal {meal}; Acceptance {acceptanceBox}; Message {messageBody}";

            //  Trigger a UI update to reflect the changes made to the 'feedback' variable.
            InvokeAsync((StateHasChanged));
        }

        /// <summary>
        /// This method is called when the user submits the list and slider form.
        /// It gathers user selections for 'myRide,' 'vacationSpot,' and 'reviewRating,'
        /// and generates feedback based on these selections.
        /// </summary>
        private void ListSliderSubmit()
        {
            // Generate feedback string incorporating the selected values.
            feedback = $"Ride {myRide}; Vacation {vacationSpot}; Review Rating {reviewRating}";

            // Invoke asynchronous method 'StateHasChanged' to trigger a re-render of the component.
            InvokeAsync(StateHasChanged);
        }


        /// <summary>
        /// Populates the 'rides' list and 'vacationSpots' list with predefined data.
        /// </summary>
        private void PopulatedList()
        {
            int i = 1;

            // Create a pretend collection from the database representing different types
            // of transportation (rides).
            rides = new List<SelectionView>();
            rides.Add(new SelectionView() { ValueID = i++, DisplayText = "Car" });
            rides.Add(new SelectionView() { ValueID = i++, DisplayText = "Bus" });
            rides.Add(new SelectionView() { ValueID = i++, DisplayText = "Bike" });
            rides.Add(new SelectionView() { ValueID = i++, DisplayText = "Motorcycle" });
            rides.Add(new SelectionView() { ValueID = i++, DisplayText = "Boat" });
            rides.Add(new SelectionView() { ValueID = i++, DisplayText = "Plane" });

            // Sort the 'rides' list alphabetically based on the 'DisplayText' property.
            rides.Sort((x, y) => x.DisplayText.CompareTo(y.DisplayText));

            // Initialize and populate the 'vacationSpots' list with predefined vacation destinations.
            vacationSpots = new List<string>();
            vacationSpots.Add("California");
            vacationSpots.Add("Caribbean");
            vacationSpots.Add("Cruising");
            vacationSpots.Add("Europe");
            vacationSpots.Add("Florida");
            vacationSpots.Add("Mexico");
        }

        #endregion
        }
}
