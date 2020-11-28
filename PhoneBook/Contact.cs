using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    class Contact : INotifyPropertyChanged

    {
        private string firstName;
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(FullInfo));
                }

            }
        }
        private string secondName;
        public string LastName
        {
            get
            {
                return secondName;
            }
            set
            {
                if (secondName != value)
                {
                    secondName = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(FullInfo));
                }
            }
        }
        private string phoneNumber;
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                if (phoneNumber != value)
                {
                    phoneNumber = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(FullInfo));
                }
            }
        }
        private string operatorType;
        public string OperatorType
        {
            get
            {
                return operatorType;
            }
            set
            {
                if (operatorType != value)
                {
                    operatorType = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(FullInfo));
                }
            }
        }
        public Contact(string firstName,string lastName,string phone,string operatorType)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phone;
            OperatorType = operatorType;
        }
        public string FullInfo => $"{LastName} {FirstName}";
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
