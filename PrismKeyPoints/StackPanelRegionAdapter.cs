using System.Windows;
using System.Windows.Controls;
using Prism.Regions;
namespace PrismKeyPoints;
public class StackPanelRegionAdapter : RegionAdapterBase<StackPanel>
{
    public StackPanelRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
    {
    }
    protected override void Adapt(IRegion region, StackPanel regionTarget)
    {
        //处理动态添加内容
        region.Views.CollectionChanged += (s, e) =>
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach (FrameworkElement item in e.NewItems)
                {
                    regionTarget.Children.Add(item);
                }
            }
        };
    }
    protected override IRegion CreateRegion()
    {
        return new Region();
    }
}

