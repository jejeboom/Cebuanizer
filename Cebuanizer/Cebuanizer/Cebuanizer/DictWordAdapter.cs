using System;
using Android.Widget;
using System.Collections.Generic;
using Android.Content;
using Android.Views;

namespace Cebuanizer
{
	public class DictWordAdapter : BaseAdapter<DictWordModel>
	{
		private readonly IList<DictWordModel> _items;
		private readonly Context _context;

		public DictWordAdapter(Context context, IList<DictWordModel> items)
		{
			_items = items;
			_context = context;
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var item = _items[position];
			var view = convertView;

			if (view == null)
			{
				var inflater = LayoutInflater.FromContext(_context);
				view = inflater.Inflate(Resource.Layout.DictListRow, parent, false);
			}

			view.FindViewById<TextView>(Resource.Id.listTextTag).Text = item.strTag;
			view.FindViewById<TextView>(Resource.Id.listTextCeb).Text = item.strCeb;

			return view;
		}

		public override int Count
		{
			get { return _items.Count; }
		}

		public override DictWordModel this[int position]
		{
			get { return _items[position]; }
		}
	}
}

