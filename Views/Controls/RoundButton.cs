using System.Windows;
using System.Windows.Controls;

namespace CRUDLibrary.Views.Controls;

/// <summary>
/// Represents a circular button with configurable size, stroke thickness, and path margin.
/// </summary>
public class RoundButton : Button
{
    /// <summary>
    /// Gets or sets the height and width of the button.
    /// Changing this value automatically updates <see cref="Radius"/>, <see cref="StrokeThicknessVal"/>, and <see cref="PathMarginVal"/>.
    /// </summary>
    public int HeightWidth
    {
        get => (int)GetValue(HeightWidthProperty);
        set
        {
            SetValue(HeightWidthProperty, value);
            Radius = value / 2.0;
            StrokeThicknessVal = value * 0.0625;
            PathMarginVal = value * 0.25;
        }
    }

    /// <summary>
    /// Gets the radius of the button, which is automatically computed as half of <see cref="HeightWidth"/>.
    /// </summary>
    public double Radius
    {
        get => (double)GetValue(RadiusProperty);
        private set => SetValue(RadiusPropertyKey, value);
    }

    /// <summary>
    /// Gets the stroke thickness of the button, which is a fraction of <see cref="HeightWidth"/>.
    /// </summary>
    public double StrokeThicknessVal
    {
        get => (double)GetValue(StrokeThicknessProperty);
        private set => SetValue(StrokeThicknessPropertyKey, value);
    }

    /// <summary>
    /// Gets the margin for the inner path element, which is a fraction of <see cref="HeightWidth"/>.
    /// </summary>
    public double PathMarginVal
    {
        get => (double)GetValue(PathMarginProperty);
        private set => SetValue(PathMarginPropertyKey, value);
    }

    /// <summary>
    /// Identifies the <see cref="HeightWidth"/> dependency property.
    /// Used to dynamically resize the button while maintaining its circular shape.
    /// </summary>
    public static readonly DependencyProperty HeightWidthProperty =
        DependencyProperty.Register(
            nameof(HeightWidth),
            typeof(int),
            typeof(RoundButton),
            new PropertyMetadata(40, OnHeightWidthChanged)
        );

    /// <summary>
    /// Identifies the <see cref="Radius"/> dependency property key.
    /// Used to store the computed radius value.
    /// </summary>
    private static readonly DependencyPropertyKey RadiusPropertyKey =
        DependencyProperty.RegisterReadOnly(
            nameof(Radius),
            typeof(double),
            typeof(RoundButton),
            new PropertyMetadata(20.5)
        );

    /// <summary>
    /// Identifies the <see cref="Radius"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty RadiusProperty = RadiusPropertyKey.DependencyProperty;

    /// <summary>
    /// Identifies the <see cref="StrokeThicknessVal"/> dependency property key.
    /// Used to store the computed stroke thickness value.
    /// </summary>
    private static readonly DependencyPropertyKey StrokeThicknessPropertyKey =
        DependencyProperty.RegisterReadOnly(
            nameof(StrokeThicknessVal),
            typeof(double),
            typeof(RoundButton),
            new PropertyMetadata(2.5625)
        );

    /// <summary>
    /// Identifies the <see cref="StrokeThicknessVal"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty StrokeThicknessProperty = StrokeThicknessPropertyKey.DependencyProperty;

    /// <summary>
    /// Identifies the <see cref="PathMarginVal"/> dependency property key.
    /// Used to store the computed path margin value.
    /// </summary>
    private static readonly DependencyPropertyKey PathMarginPropertyKey =
        DependencyProperty.RegisterReadOnly(
            nameof(PathMarginVal),
            typeof(double),
            typeof(RoundButton),
            new PropertyMetadata(10.25)
        );

    /// <summary>
    /// Identifies the <see cref="PathMarginVal"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty PathMarginProperty = PathMarginPropertyKey.DependencyProperty;

    /// <summary>
    /// Initializes static members of the <see cref="RoundButton"/> class.
    /// Overrides the default style key to apply a custom control template.
    /// </summary>
    static RoundButton()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(RoundButton),
            new FrameworkPropertyMetadata(typeof(RoundButton))
        );
    }

    /// <summary>
    /// Handles changes to the <see cref="HeightWidth"/> property.
    /// Updates the radius, stroke thickness, and path margin dynamically.
    /// </summary>
    /// <param name="d">The dependency object that changed.</param>
    /// <param name="e">The event arguments containing the new value.</param>
    private static void OnHeightWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is RoundButton roundButton)
        {
            double newHeightWidth = Convert.ToDouble(e.NewValue);
            roundButton.Radius = newHeightWidth / 2.0;
            roundButton.StrokeThicknessVal = newHeightWidth * 0.0625;
            roundButton.PathMarginVal = newHeightWidth * 0.25;
        }
    }
}
