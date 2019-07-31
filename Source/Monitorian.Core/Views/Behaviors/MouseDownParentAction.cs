﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace Monitorian.Core.Views.Behaviors
{
	public class MouseDownParentAction : TriggerAction<DependencyObject>
	{
		public MouseButton MouseButton
		{
			get { return (MouseButton)GetValue(MouseButtonProperty); }
			set { SetValue(MouseButtonProperty, value); }
		}
		public static readonly DependencyProperty MouseButtonProperty =
			DependencyProperty.Register(
				"MouseButton",
				typeof(MouseButton),
				typeof(MouseDownParentAction),
				new PropertyMetadata(default(MouseButton)));

		private UIElement _parent;

		protected override void Invoke(object parameter)
		{
			if (_parent is null)
				_parent = VisualTreeHelper.GetParent(this.AssociatedObject) as UIElement;

			var args = new MouseButtonEventArgs(Mouse.PrimaryDevice, Environment.TickCount, MouseButton) { RoutedEvent = Mouse.MouseDownEvent };
			_parent?.RaiseEvent(args);
		}
	}
}