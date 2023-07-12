namespace i18n_l10n_MVC_NETCore.Converters
{
    public static class CustomImperialSystemConverter
    {
        public enum MetricSystemWeightUnit { 
            Gramm,
            Kilogramm
        }
        public enum MetricSystemLengthUnit
        {
            Meter,
            Centimeter
        }
        public enum MetricSystemVolumeUnit
        {
            Liter,
            Milliliter
        }

        public enum MetricSystemSquareUnit
        {
            SquareKilometers,
        }

        public static bool TryConvertToPounds(double metricWeight, MetricSystemWeightUnit unit, ref double pounds) {
            double weightInKilos; 
            switch(unit)
            {
                case MetricSystemWeightUnit.Gramm: weightInKilos = metricWeight / 1000; break;
                case MetricSystemWeightUnit.Kilogramm: weightInKilos = metricWeight; break;
                default: return false;
            }

            pounds = weightInKilos * 2.20462d;
            return true;
        }

        public static bool TryConvertToInches(double metricLength, MetricSystemLengthUnit unit, ref double inches)
        {
            double lengthInCentimeters;
            switch (unit)
            {
                case MetricSystemLengthUnit.Meter: lengthInCentimeters = metricLength * 100; break;
                case MetricSystemLengthUnit.Centimeter: lengthInCentimeters = metricLength; break;
                default: return false;
            }

            inches = lengthInCentimeters / 2.54d;
            return true;
        }

        public static bool TryConvertToFluidOunces(double metricVolume, MetricSystemVolumeUnit unit, ref double flounces)
        {
            double volumeInMilliliters;
            switch (unit)
            {
                case MetricSystemVolumeUnit.Liter: volumeInMilliliters = metricVolume * 1000; break;
                case MetricSystemVolumeUnit.Milliliter: volumeInMilliliters = metricVolume; break;
                default: return false;
            }

            flounces = volumeInMilliliters * 0.03381402d;
            return true;
        }

        public static bool TryConvertToSquareMiles(double metricSquare, MetricSystemSquareUnit unit, ref double squareMiles)
        {
            double squareInSquareKilometeres;
            switch (unit)
            {
                case MetricSystemSquareUnit.SquareKilometers: squareInSquareKilometeres = metricSquare; break;
                default: return false;
            }

            squareMiles = squareInSquareKilometeres / 0.386102d;
            return true;
        }
    }
}
