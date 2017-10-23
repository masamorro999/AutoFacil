namespace AutosRA.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using AutosRA.Models;

    public class VehiclesViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Attributes
        List<Vehicle> vehicles;
        ObservableCollection<Vehicle> _vehicles;
        #endregion

        #region Properties
        public ObservableCollection<Vehicle> Vehicles
        {
            get
            {
                return _vehicles;
            }
            set
            {
                if (_vehicles != value)
                {
                    _vehicles = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Vehicles)));
                }
            }
        }
        #endregion

        #region Constructor
        public VehiclesViewModel(List<Vehicle> vehicles)
        {
            this.vehicles = vehicles;
            Vehicles = new ObservableCollection<Vehicle>(vehicles.OrderBy(x => x.Description));
        }
        #endregion
    }
}
