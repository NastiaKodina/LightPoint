using CoreLocation;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace AmazingAppWithMap
{
    public partial class TableController : UITableViewController
    {
        public List<CLLocationCoordinate2D> TableItems;
        public TableController(IntPtr handle) : base(handle)
        {
           
            TableView.Source = new TableSource(this);
            TableItems = new List<CLLocationCoordinate2D>();
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

       



    }

    public class TableSource : UITableViewSource
    {
        TableController controller;

        public TableSource(TableController controller)
        {
            this.controller = controller;
        }


        string CellIden = "TableCell";

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(CellIden);
            CLLocationCoordinate2D item = controller.TableItems[indexPath.Row];
            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Default, CellIden);
            }
            cell.TextLabel.Text = item.Latitude.ToString() + ", " + item.Longitude.ToString();
            
            return cell;
        }
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            //base.RowSelected(tableView, indexPath);
            controller.NavigationController.PopViewController(true);
            MapController ctrl = (MapController)controller.NavigationController.ViewControllers[0];
            //var ctrl1 = controller.NavigationController.PopViewController(true);
            // controller.NavigationController.
           // MapController ctrl = (MapController)controller.NavigationController.PopViewController(true);

            bool isSuccess = false;
            for(int i = 0; i < ctrl.DoubleMap.Annotations.Length; i++)
            {
                var item = ctrl.DoubleMap.Annotations[i].Coordinate;
                isSuccess = false;
                for(int j = 0; j < controller.TableItems.Count; j++)
                {
                    if (item.Equals(controller.TableItems[j]))
                    {
                        isSuccess = true;
                        break;
                    }
                }

                if(!isSuccess)
                {
                    ctrl.DoubleMap.RemoveAnnotation(ctrl.DoubleMap.Annotations[i]);
                }
            }
          
            //controller.NavigationController.PushViewController(ctrl, true);
            //ctrl.DoubleMap.Annotations[0].Coordinate
           // controller.NavigationController.PopViewController(false);
            
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return controller.TableItems.Count;
        }

        public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, Foundation.NSIndexPath indexPath)
        {
            switch (editingStyle)
            {
                case UITableViewCellEditingStyle.Delete:
                    // remove the item from the underlying data source
                    var item = controller.TableItems[indexPath.Row];
                    controller.TableItems.Remove(item);
                    // delete the row from the table
                    tableView.DeleteRows(new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Fade);
                    break;
                case UITableViewCellEditingStyle.None:
                    Console.WriteLine("CommitEditingStyle:None called");
                    break;
            }
        }
    }
}