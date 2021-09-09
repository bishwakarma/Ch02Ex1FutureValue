using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
//Here, I have used Validation attributes of the DataAnnotations namespace to add Validation rules to my model.
namespace Ch02Ex1FutureValue.Models
{
    /// <summary>
    /// FutureValueModel is a class for the Model that is stored in the Models foler. This class stores a model for a data for a page.
    /// </summary>
    public class FutureValueModel
    {
        //This model c# class has 3 properties to get and set Monthly investment, yearly interest and Number of Years for this Future Value App.
        //Making value is required for the property.
        //Hence, if the user doesn't enter a value for this property, the MVC framework generates a error msg.

        [Required(ErrorMessage = "Please enter a Monthly Investment Amount.")]
        
        //Value of the property must be within the specified range of values.

        [Range (1,500, ErrorMessage = "Monthly Investment Amount must be between 1 and 500.")]

        //Making the data type nullable with (?) next to the decimal data type. 
        //Hence, if the user doesn't enter a value for this property, the MVC framework generates a error msg.
        public decimal? MonthlyInvestment { get; set; }

        //Making value is required for the property.
        //Hence, if the user doesn't enter a value for this property, the MVC framework generates a error msg.
        //Value of the property must be within the specified range of values.
        //Making the data type nullable with (?) next to the decimal data type. 
        //Hence, if the user doesn't enter a value for this property, the MVC framework generates a error msg.

        [Required(ErrorMessage = "Please enter a Yearly interest Rate.")]
        [Range (0.1, 10.0, ErrorMessage = "Yearly Interest Rate must be between 0.1 and 10.0.")]
        public decimal? YearlyInterestRate { get; set; }

        //Making value is required for the property.
        //Hence, if the user doesn't enter a value for this property, the MVC framework generates a error msg.
        //Value of the property must be within the specified range of values.
        //Making the data type nullable with (?) next to the decimal data type. 
        //Hence, if the user doesn't enter a value for this property, the MVC framework generates a error msg.

        [Required(ErrorMessage = "Please enter a number of Years.")]
        [Range (1,50,ErrorMessage = "Number of years must be between 1 and 50.")]
        public int? NumOfYears { get; set; }

        /// <summary>
        /// CalculateFutureValue() is a custom method that does the calculaton for Future Value App.
        /// Calculation is to convert yearly value to monthly value and use a loop to calculate the future value. 
        /// </summary>
        /// <returns></returns>
        public decimal? CalculateFutureValue()
        {
            //Made a data type nullable.
            int? months = NumOfYears * 12;

            //Made a data type nullable.
            decimal? monthlyinterestRate = YearlyInterestRate / 12 / 100;

            //Made a data type nullable.
            decimal? futureValue = 0;

            for (int i = 0; i < months; i++)
            {
                futureValue = (futureValue + MonthlyInvestment) * (1 + monthlyinterestRate);
            }
            return futureValue;
        }
    }
}
