using System;
using Android.Widget;
using System.Collections.Generic;
using Android.Content;
using Android.Views;

namespace Cebuanizer
{
	public class PhraseAdapter : BaseAdapter<PhraseModel>
	{
		private readonly IList<PhraseModel> _items;
		private readonly Context _context;

		public PhraseAdapter(Context context, IList<PhraseModel> items)
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
				view = inflater.Inflate(Resource.Layout.PhraListRow, parent, false);
			}

			view.FindViewById<TextView>(Resource.Id.listPCeb).Text = item.strPCeb;
			view.FindViewById<TextView>(Resource.Id.listPTag).Text = item.strPTag;

			return view;
		}

		public override int Count
		{
			get { return _items.Count; }
		}

		public override PhraseModel this[int position]
		{
			get { return _items[position]; }
		}
	}
}

