   M S B A M L   `   `   `  ����D  @RPGEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:RPGEditor	RPGEditor  5   	       RPGEditor.MainUI   5      U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:RPGEditor     5   	   O KFluent, Version=4.0.3.394, Culture=neutral, PublicKeyToken=3e436e32a8c5546ffluenturn:fluent-ribbon  5      -   5          � Title$  RPGEditor UI Beta��5	   	   $��826.136��6#   $��1522.863��64   
�������
�������.��5      � .+�5   
   �� -   5         ��Name$ 	textBlock��5      $
��Left=�6'   $��
58,702,0,0q�6B   $
��Wrap=�6V   $��	TextBlock��6j   $	��Top=�6{   R� 5   
   -   5         R�Name$ 	treeView1��5      $	��324��6&   $��0,0,5,35q�62   ���	#FFD8D8D8���	#FFC3C0C0$��Right=�6!  $	��593��6=  $��Bottom=�6J  ��6�   Z�  � ContextMenu 5      �� 5      .@�5      m� -   5         m�Name$ DeleteItemButton��5      $��Delete Selected File��69   6W   m� 5      -   5        $ AddFileButton��5      $��Add Existing File��66   6Q   m� 5      -   5        $ 	MarkAsMod��5      $��Mark as Modded��62   6J   5      5        Fluent.Ribbon  5   
   -   5          Name$ ribbon1��5      $
��Left=�6)   $	��147��6D   $��2,-3,0,0q�6Q   $	��Top=�6c   $
��1510��6{   
���   � � 	Resources 5         RibbonBackgoundBrush��%   &	        �� 5      6"   5         Menu 5        Fluent.ApplicationMenu  5      ���#3671e7.@�5        Fluent.MenuItem  -   5          Name$ FileMenuItem��5   &   $
��File��6<   6J   5!      	   ContextualGroups	 5$      %  Fluent.RibbonContextualTabGroup  5%      -	   5        
  Name$
 	tabGroup1��5%   2      Header$ Game Management��5'   2   $y�Hidden=�5(   2   ���	#FF46A0BD���	#FF46A0BD���	#FF42ACCF6v     5)      -
   5        $
 ZipMountTabGroup1��5)   2   $y�Hidden=�6M   ���	#FF8B00FF���	#FF8B00FF���	#FF6B07BF$ 	Zip Mount��6�      Tabs. 5-        Fluent.RibbonTabItem     Header$ 	Workspace��6#   $��27��66   $��83��6B   
���   �$
��Left=�6`      Groups. 5.        Fluent.RibbonGroupBox     Header$ 	Workspace��6(   $��84��6;   $	��305��6G   
���   �$
��Left=�6|   ��6S   Z� .@�50        Fluent.Button  -   5          Name$ LoadWorkspace��50   $      Header$
 Load��6;   $��62��51      
���   �$
��Left=�6e   ��6<   Z� 6e     52      -   5        $ CloseWorkspaceButton��52   $   $ Close��6B   {�.     	LargeIcon$ Resources/close.png��53      $��54��67   
���   �$
��Left=�6x     54      -   5        $ WorkspaceSettingsButton��54   $   $ Settings��6E   $��56��6W   
���   �$
��Left=�55   Z     56      -   5        $ WorkspaceCreateButton��56   $   $	 New��6C   
���   �$
��Left=�6�     58      -   5        $ ExportModButton��58   $   $ Export��6=   {�.  
���   �$
��Left=�6�     59      -   5        $ AssetManagerButton��59   $   $ Assets��6@   
���   �$
��Left=�6�   5:      5;        5=      $
 File��6#   
���   �$
��Left=�6D   . 5>        $ Group��6(   $��84��67   $	��440��6C   .@�5@        -   5        $ 
SaveButton��5@   3   $
 Save��6$   {�.  5A       5B      5C        5F      -   5          Name$ TestGameRibbion��5F   0   $	 Run��6#   
���   �$
��Left=�6\   . 5H        $ 	Test Game��6(   $��84��6;   $	��100��6G   .@�5K        -   5        $ LaunchGame1��5K   4   $ Launch��6$   {�.  5L   1     5M      -   5        $ 
StopButton��5M   $   $
 Stop��69   {�.  6Y   5N      5O        5P      $ Plugins��6$   
���   �$
��Left=�6H   . 5Q        $ Plugins��6(   $��84��69   $	��195��6E   .@�5R        -   5        $ ModPatcherButton��5R   8   $ 
ModPatcher��6$   6R   5S      5T        5U      $ 
Map Editor��6#      
IsSelected . 
���   �$
��Left=�6\   . 5V        $ 
Map Editor��6(   $��84��6<   $	��158��6H   .@�5W        -   5        $ MapEditorLoadButton��5W   $   $
 Load��6A   6O   5X      5Z        5[      $
 Help��6#    . 
���   �$
��Left=�6V   . 5\        $
 Help��6(   $��84��66   $	��385��6B   .@�5]        -   5        $ AboutButton��5]   $   $ About��69   5^   #     5_      -   5        $ CrazyWindowButton��5_   $   $ Launch Crazy Menu��6?   5`   #     5a      -   5        $ LoadSkinButton��5a   $   $ Skins��6<   5c      5f        5h      -   5        $ GameTabItem��5h   1   $
 Game��6#   $y�hidden=�6G   . 5i        $��84��6)   $	��474��65   .@�5j        $��44��6$   $ 
Button :/ ��6/   5l      5n        5o      -   5        $ UnMountTabItem��5o   5   $ Settings��6#   $y�Hidden=�6N    .  . 5p        .@�5q        -   5        $ UnMountButton��5q   5   $ Unmount��6$   65   5r      5s      5v      �� 5w   
   -   5         ��Name$ 
tabControl��5w      $��	6,144,0,0q�6)   
���   �$
��Left=�6e   $	��650��6�   $	��Top=�6�   $
��1174��6�   ��6<   Z� 5~      � 5   
   -   5         �Name$ progressbar1��5      $
��Left=�6,   $��15��6G   $��949,623,0,0q�6S   $	��Top=�6h   $	��235��6�    J� RenderTransformOrigin$ 	-0.03,8.1&�6�    � Value$ -1Q�6�   ���	#FF2A699E��6�   Z� ��6�   Z� 6�   �� 5�   
   -   5        $ textBlock_Copy��5�      $
��Left=�6,   $��106,346,0,0q�6G   $
��Wrap=�6\   $��
Properties��6p   $	��Top=�6�   5�      5�      