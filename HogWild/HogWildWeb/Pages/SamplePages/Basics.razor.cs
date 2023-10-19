﻿namespace HogWildWeb.Pages.SamplePages
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

        #endregion
    }
}
