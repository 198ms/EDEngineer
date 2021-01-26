﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using EDEngineer.Models.Utils;
using Newtonsoft.Json;

namespace EDEngineer.Models
{
    public class Entry : INotifyPropertyChanged
    {
        public Entry(EntryData data)
        {
            Data = data;
        }

        public Entry()
        {
        }

        public EntryData Data { get; }
        private int count;
        private int favoriteCount;
        private int synthesisFavoriteCount;
        private bool highlighted;

        public int Count
        {
            get => count;
            set
            {
                if (value == count)
                {
                    return;
                }

                var oldValue = count;
                count = value;
                OnPropertyChanged(oldValue, count);
                OnPropertyChanged(nameof(CarryingProgress));
            }
        }

        [JsonIgnore]
        public int FavoriteCount
        {
            get => favoriteCount;
            set
            {
                if (value == favoriteCount)
                {
                    return;
                }

                var oldValue = favoriteCount;
                favoriteCount = value;
                OnPropertyChanged(oldValue, favoriteCount);
            }
        }

        [JsonIgnore]
        public int SynthesisFavoriteCount
        {
            get => synthesisFavoriteCount;
            set
            {
                if (value == synthesisFavoriteCount)
                {
                    return;
                }

                var oldValue = synthesisFavoriteCount;
                synthesisFavoriteCount = value;
                OnPropertyChanged(oldValue, synthesisFavoriteCount);
            }
        }

        [JsonIgnore]
        public bool Highlighted
        {
            get => highlighted;
            set
            {
                if (value == highlighted)
                {
                    return;
                }

                highlighted = value;
                OnPropertyChanged();
            }
        }

        [JsonIgnore]
        public double CarryingProgress => Count / (double) Data.MaximumCapacity * 100;

        public override string ToString()
        {
            return Data.Name + "(" + Count + ")";
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(int oldValue, int newValue, [CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedExtendedEventArgs<int>(propertyName, oldValue, newValue));
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}