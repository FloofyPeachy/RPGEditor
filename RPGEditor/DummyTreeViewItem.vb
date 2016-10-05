Public Class DummyTreeViewItem
    	Inherits TreeViewItem
    Public Sub New()
		MyBase.New()
        Header = "Dummy"
		MyBase.Tag = "Dummy"
	End Sub
End Class
