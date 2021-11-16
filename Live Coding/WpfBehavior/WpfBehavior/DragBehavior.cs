using Microsoft.Xaml.Behaviors; // Nuget: Microsoft.Xaml.Behaviors.Wpf
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WpfBehavior
{
    public class DragBehavior : Behavior<UIElement>
    {
        private Point elementStartPoint;
        private Point mouseStartPoint;
        private TranslateTransform transform = new TranslateTransform();

        protected override void OnAttached()
        {
            Window window = Application.Current.MainWindow;
            AssociatedObject.RenderTransform = transform;

            // Linke Maustaste wird gedrückt
            AssociatedObject.MouseLeftButtonDown += (sender, e) =>
             {
                 elementStartPoint = AssociatedObject.TranslatePoint(new Point(), window);
                 mouseStartPoint = e.GetPosition(window);
                 // Objekt "fangen"
                 AssociatedObject.CaptureMouse();
             };

            // Linke Maustaste losgelassen
            AssociatedObject.MouseLeftButtonUp += (sender, e) =>
            {
                // Objekt loslassen
                AssociatedObject.ReleaseMouseCapture();
            };

            // Mausbewegung
            AssociatedObject.MouseMove += (sender, e) =>
              {
                  Vector delta = e.GetPosition(window) - mouseStartPoint;

                  // Wenn Objekt "gefangen"...
                  if (AssociatedObject.IsMouseCaptured)
                  {
                      transform.X = delta.X;
                      transform.Y = delta.Y;
                  }
              };
        }
    }
}
