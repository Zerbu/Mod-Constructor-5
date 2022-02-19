using GongSolutions.Wpf.DragDrop;
using System.Linq;
using System.Windows;

namespace Constructor5.UI.Shared
{
    public class OwnTypeDropHandler : IDropTarget
    {
        public void DragOver(IDropInfo dropInfo)
        {
            if (!dropInfo.TargetCollection.Cast<object>().Contains(dropInfo.Data))
            {
                return;
            }

            dropInfo.DropTargetAdorner = DropTargetAdorners.Insert;
            dropInfo.Effects = DragDropEffects.Move;
        }

        public void Drop(IDropInfo dropInfo)
        {
            /*var sourceItem = dropInfo.Data as IElementNode;
            var targetItem = dropInfo.TargetItem as IElementNode;*/

            MessageBox.Show("Dropped?");

            /*var collection = sourceItem?.GetParent();
            collection?.Move(collection.IndexOf(sourceItem), collection.IndexOf(targetItem));*/
        }

        void IDropTarget.DragEnter(IDropInfo dropInfo)
        {
        }

        void IDropTarget.DragLeave(IDropInfo dropInfo)
        {
        }
    }
}
