package md5ca0462fa56b624569aa2b69eecb179a7;


public class actStartUp
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Cebuanizer.actStartUp, Cebuanizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", actStartUp.class, __md_methods);
	}


	public actStartUp () throws java.lang.Throwable
	{
		super ();
		if (getClass () == actStartUp.class)
			mono.android.TypeManager.Activate ("Cebuanizer.actStartUp, Cebuanizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}