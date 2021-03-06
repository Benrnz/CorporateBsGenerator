using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using com.refractored.fab;
using CorporateBsGenerator;
using CorporateBsGenerator.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ListView = Xamarin.Forms.ListView;
using Path = System.IO.Path;

[assembly: ExportRenderer(typeof(FloatingActionButtonView), typeof(FloatingActionButtonViewRenderer))]

namespace CorporateBsGenerator.Droid
{
    public class FloatingActionButtonViewRenderer : ViewRenderer<FloatingActionButtonView, FrameLayout>
    {
        private const int MARGIN_DIPS = 16;
        private const int FAB_HEIGHT_NORMAL = 56;
        private const int FAB_HEIGHT_MINI = 40;
        private const int FAB_FRAME_HEIGHT_WITH_PADDING = MARGIN_DIPS * 2 + FAB_HEIGHT_NORMAL;
        private const int FAB_FRAME_WIDTH_WITH_PADDING = MARGIN_DIPS * 2 + FAB_HEIGHT_NORMAL;
        private const int FAB_MINI_FRAME_HEIGHT_WITH_PADDING = MARGIN_DIPS * 2 + FAB_HEIGHT_MINI;
        private const int FAB_MINI_FRAME_WIDTH_WITH_PADDING = MARGIN_DIPS * 2 + FAB_HEIGHT_MINI;
        private readonly Context context;
        private readonly FloatingActionButton fab;
        private int appearingListItemIndex;

        public FloatingActionButtonViewRenderer()
        {
            this.context = Forms.Context;

            var d = this.context.Resources.DisplayMetrics.Density;
            var margin = (int) (MARGIN_DIPS * d); // margin in pixels

            this.fab = new FloatingActionButton(this.context);
            var lp = new FrameLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent);
            lp.Gravity = GravityFlags.CenterVertical | GravityFlags.CenterHorizontal;
            lp.LeftMargin = margin;
            lp.TopMargin = margin;
            lp.BottomMargin = margin;
            lp.RightMargin = margin;
            this.fab.LayoutParameters = lp;
        }

        public void Hide(bool animate = true)
        {
            this.fab.Hide(animate);
        }

        public void Show(bool animate = true)
        {
            this.fab.Show(animate);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<FloatingActionButtonView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
                return;

            if (e.OldElement != null)
            {
                e.OldElement.PropertyChanged -= HandlePropertyChanged;
                // Experimental - proper hiding and showing of the FAB is dependent on the objects in the list being unique.
                if (e.OldElement.ParentList != null)
                {
                    e.OldElement.ParentList.ItemAppearing -= OnListItemAppearing;
                    e.OldElement.ParentList.ItemDisappearing -= OnListItemDisappearing;
                }
            }

            if (Element != null)
            {
                Element.PropertyChanged += HandlePropertyChanged;
                // Experimental - proper hiding and showing of the FAB is dependent on the objects in the list being unique.
                if (Element.ParentList != null)
                {
                    Element.ParentList.ItemAppearing += OnListItemAppearing;
                    Element.ParentList.ItemDisappearing += OnListItemDisappearing;
                }
            }

            Element.Show = Show;
            Element.Hide = Hide;

            SetFabImage(Element.ImageName);
            SetFabSize(Element.Size);

            this.fab.ColorNormal = Element.ColorNormal.ToAndroid();
            this.fab.ColorPressed = Element.ColorPressed.ToAndroid();
            this.fab.ColorRipple = Element.ColorRipple.ToAndroid();
            this.fab.HasShadow = Element.HasShadow;
            this.fab.Click += Fab_Click;

            var frame = new FrameLayout(this.context);
            frame.RemoveAllViews();
            frame.AddView(this.fab);

            SetNativeControl(frame);
        }

        private void Fab_Click(object sender, EventArgs e)
        {
            Action<object, EventArgs> clicked = Element.Clicked;
            if (Element != null)
            {
                clicked?.Invoke(sender, e);
                if (Element.Command != null && Element.Command.CanExecute(null)) Element.Command.Execute(null);
            }
        }

        private void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Content")
            {
                Tracker.UpdateLayout();
            }
            else if (e.PropertyName == FloatingActionButtonView.ColorNormalProperty.PropertyName)
            {
                this.fab.ColorNormal = Element.ColorNormal.ToAndroid();
            }
            else if (e.PropertyName == FloatingActionButtonView.ColorPressedProperty.PropertyName)
            {
                this.fab.ColorPressed = Element.ColorPressed.ToAndroid();
            }
            else if (e.PropertyName == FloatingActionButtonView.ColorRippleProperty.PropertyName)
            {
                this.fab.ColorRipple = Element.ColorRipple.ToAndroid();
            }
            else if (e.PropertyName == FloatingActionButtonView.ImageNameProperty.PropertyName)
            {
                SetFabImage(Element.ImageName);
            }
            else if (e.PropertyName == FloatingActionButtonView.SizeProperty.PropertyName)
            {
                SetFabSize(Element.Size);
            }
            else if (e.PropertyName == FloatingActionButtonView.HasShadowProperty.PropertyName)
            {
                this.fab.HasShadow = Element.HasShadow;
            }
        }

        private void OnListItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            // Experimental - proper hiding and showing of the FAB is dependent on the objects in the list being unique.
            var list = sender as ListView;
            var items = list?.ItemsSource as IList;
            if (items != null)
            {
                var index = items.IndexOf(e.Item);
                if (index < this.appearingListItemIndex)
                {
                    this.appearingListItemIndex = index;
                    this.fab.Show();
                }
                else
                {
                    this.appearingListItemIndex = index;
                }
            }
        }

        private void OnListItemDisappearing(object sender, ItemVisibilityEventArgs e)
        {
            // Experimental - proper hiding and showing of the FAB is dependent on the objects in the list being unique.
            var list = sender as ListView;
            var items = list?.ItemsSource as IList;
            if (items != null)
            {
                var index = items.IndexOf(e.Item);
                if (index < this.appearingListItemIndex && index != 0)
                {
                    this.appearingListItemIndex = index;
                    this.fab.Hide();
                }
                else
                {
                    this.appearingListItemIndex = index;
                }
            }
        }

        private void SetFabImage(string imageName)
        {
            if (!string.IsNullOrWhiteSpace(imageName))
            {
                try
                {
                    var drawableNameWithoutExtension = Path.GetFileNameWithoutExtension(imageName);
                    var resources = this.context.Resources;
                    var imageResourceName = resources.GetIdentifier(drawableNameWithoutExtension, "drawable", this.context.PackageName);
                    this.fab.SetImageBitmap(BitmapFactory.DecodeResource(this.context.Resources, imageResourceName));
                }
                catch (Exception ex)
                {
                    throw new FileNotFoundException("There was no Android Drawable by that name.", ex);
                }
            }
        }

        private void SetFabSize(FloatingActionButtonSize size)
        {
            if (size == FloatingActionButtonSize.Mini)
            {
                this.fab.Size = FabSize.Mini;
                Element.WidthRequest = FAB_MINI_FRAME_WIDTH_WITH_PADDING;
                Element.HeightRequest = FAB_MINI_FRAME_HEIGHT_WITH_PADDING;
            }
            else
            {
                this.fab.Size = FabSize.Normal;
                Element.WidthRequest = FAB_FRAME_WIDTH_WITH_PADDING;
                Element.HeightRequest = FAB_FRAME_HEIGHT_WITH_PADDING;
            }
        }
    }
}