   M S B A M L   `   `   `  ���� O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source   ScrollBarButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �Name'   !System.Windows.VisualStateManager    VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState	   
Storyboard
 g� Duration �� TargetProperty �� 
TargetName R� KeyTime 0 ,ScrollbarPageButtonArrowHoverBackgroundBrush R� Value 2 .ScrollbarPageButtonArrowPressedBackgroundBrush 3 /ScrollbarPageButtonArrowDisabledBackgroundBrush  TransparentBrush F�Name �� Stretch + 'ScrollbarPageButtonArrowBackgroundBrush  ScrollBarPageButtonStyle  HScrollBarThumbStyle ' #HScrollbarThumbHoverBackgroundBrush )	 %HScrollbarThumbPressedBackgroundBrush *
 &HScrollbarThumbDisabledBackgroundBrush ��Name " HScrollbarThumbBackgroundBrush  VScrollBarThumbStyle ' #VScrollbarThumbHoverBackgroundBrush ) %VScrollbarThumbPressedBackgroundBrush * &VScrollbarThumbDisabledBackgroundBrush " VScrollbarThumbBackgroundBrush  ScrollBarStyle J� SnapsToDevicePixels � RowDefinitions   Transitions%  System.Windows.VisualTransition   GeneratedDuration9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  ScrollbarBackgroundBrush ��Name �� LineUpCommand ]�Name ]� DecreaseRepeatButton �� PageUpCommand ]� IncreaseRepeatButton �� PageDownCommand ]� Thumb  n�Name! �� LineDownCommand" J� RenderTransformOrigin# �� Angle$ �� Triggers% P� Property& P� Value' � ColumnDefinitions( �� LineLeftCommand) J� Opacity* �� PageLeftCommand+ �� PageRightCommand, �� LineRightCommand  ScrollViewerStyle  ForegroundBrush- ��Name. �� CanContentScroll/ �� CanHorizontallyScroll0 �� CanVerticallyScroll % !ScrollViewerCornerBackgroundBrush1 ��Name4  .System.Windows.Automation.AutomationProperties2   AutomationId3 � Cursor4 �� ScrollableHeight5 � Maximum6 � Minimum*7 �� #ComputedVerticalScrollBarVisibility8 �� ViewportHeight9 �� ViewportSize: � Value; �� Mode< �� RelativeSource= �� ScrollableWidth> �� Orientation,? �� %ComputedHorizontalScrollBarVisibility@ �� ViewportWidth $  TextBoxValidationToolTipTemplateA T� X	B   ToC   
Storyboard	D W� ToE W� EasingFunction-  'System.Windows.Media.Animation.BackEaseF   	Amplitude7  1System.Windows.Media.Animation.EasingFunctionBaseG   
EasingMode ( $ValidationToolTipTemplateShadowBrush  ValidationErrorElement  LightForegroundBrushH � UseLayoutRounding   ComboBoxEditableTextBoxStyle  TextBoxFocusedBrushI ��Name  ComboBoxEditableTemplate  System.Windows.Visibility  ComboBoxBackgroundBrush  ComboBoxBorderBrush   ComboBoxHoverBackgroundBrush   ComboBoxHoverBorderBrushJ �NameK � AllowsTransparencyL ��Name ! PopupBackgroundBrush " PopupBorderBrushM �� MaxDropDownHeightN �� CornerRadiusO �� ElementNameP �� ClearTypeHintQ ��Name-	  'System.Windows.Input.KeyboardNavigationR 	  DirectionalNavigation # ComboBoxToggleButtonStyleS d� 	IsCheckedT ��NameU �� 
IsReadOnly $ ComboBoxFocusedBorderBrush #% ComboBoxDisabledBackgroundBrushV �� TriggersW �� 
TargetName & ComboBoxStyle ' ComboBoxItemStyleX ��NameY J� IsHitTestVisibleZ �� SelectionBoxItemTemplate[ �� SelectionBoxItem#\ �� SelectionBoxItemStringFormat] �� ContentStringFormat^ P� 
SourceName ( TextBoxStyle ) TextBoxBackgroundBrush * TextBoxBorderBrush + TextBoxHoverBorderBrush , TextBoxHoverBackgroundBrush "- TextBoxReadOnlyBackgroundBrush . DisabledVisualElement_ ^� ToolTip` _�Namea _� 	Placementb � DataContextc _� PlacementTarget / ListBoxStyle 0 ListBoxBackgroundBrush 1 ListBoxBorderBrush 2 ListBoxItemStyle 3 ValidationToolTipTemplated � Triggerse :� RoutedEvent�� H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml     8d2http://schemas.microsoft.com/expression/blend/2008  Bmc;http://schemas.openxmlformats.org/markup-compatibility/2006  1System&clr-namespace:System;assembly=mscorlib    �� $ Theme.Colors.xaml?��� $ Styles.Shared.xaml?�%�6  &	        7  7  7  7  7  &	 |    &	 �    7  7 	 7 
 7  7  &	 �    7  7  7  7  7  &	 �    7  7   7  7  7  7   7  7  7  7  &	 �    7  7  7  7  &	 �    7  7  7  7  7  7  &	 �    7  7  7  &	 b    7  7  7  7   7 ! 7 " 7  7 # 7  7 $ 7 % &	& �    7  7  7  7 ' 7  7  7  7  7   7 ! 7 " 7  7 # 7 $ 7 % 7  7  7  &	( &(    7  7 ) 7 * 7  7  7 + 7 , 7 - 7 . 7 . 7  7  7  7  7  &	/ �/    7 0 7 1 7  7 2 7  7  7 3 7  7  7  �� " ��.���  � ��$ 30����  � ��$ 30����  � ��$ 0q���  �@�OverridesDefaultStyle . ��  � |� .  ��  � �� .  ��  � �� �� " ��.R�� $ grid1��   CommonStates��.   
Normal��  	MouseOver��.	 �� .��T� $
 0D�$
 Fill�$ Arrow��..�i� $ 0��8     Pressed��.	 �� .��T� $
 0D�$
 Fill�$ Arrow��..�i� $ 0��8    Disabled��.	 �� .��T� $
 0D�$
 Fill�$ Arrow��..�i� $ 0��8  .+��� 8�� $��-5q�F� $ Arrow��+�����2G �X
Ѹ��X
�П�б�	��2G �X
$��6��$ Uniform=�$��10��8�� #��z���� " ��.���  �@�OverridesDefaultStyle . ��  � ��
 ���� ��  � |� .  ��  � �� .  ��  � �� �� " ��.R��� #��z��#��z��#��z��   CommonStates��.   
Normal��  	MouseOver��  Pressed��  Disabled���� " n�.���  � ��$ 20����  � ��$ 30����  �@�OverridesDefaultStyle . ��  � �� .  ��  � �� �� " n�.R�� $��0q�   CommonStates��.   
Normal��  	MouseOver��.	 �� .��T� $
 0D�$
 Fill�$ Thumb��..�i� $ 0��8     Pressed��.	 �� .��T� $
 0D�$
 Fill�$ Thumb��..�i� $ 0��8    Disabled��.	 �� .��T� $
 0D�$
 Fill�$ Thumb��..�i� $ 0��8  .+��� 8�� $��-5q��� $ Thumb��$��1q�8�� $��8���� " n�.���  �@�OverridesDefaultStyle . ��  � ��$ 30����  � ��$ 20����  �@��IsPressAndHoldEnabled .  ��  � �� �� " n�.R�� $
 grid��$
��Auto��$
��Auto��   CommonStates��.   
Normal��  	MouseOver��.	 �� .��T� $
 0D�$
 Fill�$ Thumb��..�i� $ 0��8     Pressed��.	 �� .��T� $
 0D�$
 Fill�$ Thumb��..�i� $ 0��8    Disabled��.	 �� .��T� $
 0D�$
 Fill�$ Thumb��..�i� $ 0��8  .+��� 8�� $��-5q��� $ Thumb��8�� $��8���� " ��.���  �@��IsPressAndHoldEnabled .  ��  �@��IsFlicksEnabled .  ��  � ��$ 30����  � ��$ 30����  � �� �� " ��.R�� $ Bg�� .  �� $��30 ��� $��0.00001* ��� $��30 �   CommonStates��   $ 0:0:0.3D�.   
Normal��  	MouseOver��  Disabled��.	 �� .��U� $ (UIElement.Opacity)�$ repeatButton��.\�  $ 0��$	 0.6Q�U� $ (UIElement.Opacity)�$ repeatButton1��.\�  $ 0��$	 0.6Q�U� $ (UIElement.Opacity)�$ thumb��.\�  $ 0��$ 0Q�.+��� $��3��8��  $��0q��� $ repeatButton��#��Z {�. 8�� $��Center=�]� $ 
PART_Track����. {�. $��1�� �� #��Z 8��  �� #��Z 8��  n� $  thumb��8�� $��Center=�$��30���� $ repeatButton1��#��Z! {�. $��2��8�� $" 0.5,0.5&�$��Center=�z�V� .~��� �� �� $	# 180Q�T� $ P� % �@��Orientation$& 
Horizontal=�. ���  � ��$
 Auto����  � ��$ 0����  � ��$ 30����  � ��$ 30����  � �� �� " ��.R�� $ Bg�� . ' �� $��30 ��� $��0.00001* ��� $��30 �   CommonStates��   $ 0:0:0.3D�.   
Normal��  	MouseOver��.	 �� .��U� $ (UIElement.Opacity)�$ repeatButton��.\�  $ 0��$ 1Q�U� $ (UIElement.Opacity)�$ repeatButton1��.\�  $ 0��$ 1Q�  Disabled��.+��� $��5��8�� �� $ repeatButton��#��Z( {�. #���   $) 1Q�$" 0.5,0.5&�$��Center=�z�V� .~��� �� �� $	# -90Q�T� ]� $ 
PART_Track��$��1��{�.  �� #��Z* 8��  �� #��Z+ 8��  n� 8��	 $��Center=�$��30���� $ repeatButton1��$��2��#��Z, {�. #���   $) 1Q�$" 0.5,0.5&�$��Center=�z�V� .~��� �� �� $# 90Q�T� �� " ��.���  � ��8   ��  � ��$
 Left=���  � ��$	 Top=���  � ��$
 Auto=���  � ��$ 0q���  � ��$ 1q���  � �� �� " ��.R�� $
 Grid��' �� $��* ��� $
��Auto � �� $��* ��� $
��Auto �.+��� $!- PART_ScrollContentPresenter��#. z��/ .  0 .  #��z��#��z��$��0��#��z��$��0���� $��1��8�� $��1���� $1 PART_VerticalScrollBar��$2 VerticalScrollBar��$3 Arrow��$��1��#5 z4 $6 0Q�$��0��#y�z7 #9 z8 8�� : �� *VerticalOffset+$; OneWay=�< �� *TemplatedParent+�� $1 PART_HorizontalScrollBar��$2 HorizontalScrollBar��$3 Arrow��$��0��#5 z= $6 0Q�$> 
Horizontal=�$��1��#y�z? #9 z@ 8�� : �� *HorizontalOffset+$; OneWay=�< �� *TemplatedParent+�� .R�� $
 Root��$	��5,0q�$) 0Q�$	" 0,0&�z�T� 	xform��$	A -25Q�   
OpenStates��   $ 0D�  $ 0:0:0.2D�$
B Open��.C �� .��W� $
 0:0:0.2D�$D 0X�$ X�$ xform��E   $F .3Q�$G EaseOut=�W� $
 0:0:0.2D�$D 1X�$ Opacity�$
 Root��.   
Closed��.	 �� .��W� $
 0D�$D 0X�$ Opacity�$
 Root��  Open��.	 �� .��W� $
 0D�$D 0X�$ X�$ xform��W� $
 0D�$D 1X�$ Opacity�$
 Root��.+��� 8��  $��	4,4,-4,-4q�$
) 0.02Q��� 8�� $��	3,3,-3,-3q�$
) 0.08Q��� 8�� $��	2,2,-2,-2q�$
) 0.15Q��� 8�� $��	1,1,-1,-1q�$
) 0.21Q��� 8�� �� ._��� 8�� $	��250��$��8,4,8,4q�$
��Wrap=�H .  ���� *.,(Validation.Errors).CurrentItem.ErrorContent+�� " ��.���  � ��8   ��  � ��$ 14.667(���  � ��$ Segoe UI)���  �@�OverridesDefaultStyle . ��  �@J�	AllowDrop . ��  � ��$ 0����  � ��$ 30����  � ��$	 6,4q���  �@�FocusVisualStyle Z� ��  �@��SelectionBrush8  ��  �@��SelectionOpacity$	 0.4Q���  � �� �� " ��.R��� $I PART_ContentHost��8�� 
������ |�.  $��Hidden=�$��Hidden=�   CommonStates��.   
Normal��  Disabled��.	 �� .��U� $ (UIElement.Opacity)�$ PART_ContentHost��.\�  $ 0��$	 0.3Q�  ReadOnly��  	MouseOver���� " ��.R�� $ MainGrid�� . ' �� $��* ��� $
��Auto �   CommonStates��.   
Normal��  	MouseOver��.	 �� .��T� $ (UIElement.Visibility)�$ hover��..�i� $ 0��  Visible=�  Disabled��.	 �� .��T� $ (UIElement.Visibility)�$ disabled��..�i� $ 0��  Visible=�  FocusStates��.   	Unfocused��  Focused��.	 �� .��T� $ (UIElement.Visibility)�$ focused��..�i� $ 0��  Visible=�  FocusedDropDown��.	 �� .��T� $ (UIElement.Visibility)�$ focused��..�i� $ 0��  Visible=�.+��� $ normal��8��  8�� $��1��$��2���� $ hover��8�� 8�� $��1��$y�	Collapsed=�$��2��� $J 
PART_Popup��K . $��2��$��1q�#��� .�$��Bottom=����� *IsDropDownOpen+< �� *TemplatedParent+.���� $L DropDownBorder��$��Stretch=�8�� 8�� $��1q�#��zM $N 2������ *ActualWidth+$O MainGrid��._��� $I DropDownScrollViewer��8�� .��� $P Enabled=�.+��� $
��Left=�$��0��$	��Top=�$��0��.+��� $ 
OpaqueRect������ *
Background+$O DropDownBorder������ *ActualHeight+$O DropDownBorder������ *ActualWidth+$O DropDownBorder���� $Q ItemsPresenter��$R 	Contained=�# z d� #��z��#��z��$��0��8�� S �� *IsDropDownOpen+$; TwoWay=�< �� *TemplatedParent+�� $T PART_EditableTextBox��#��z��8�� #��z��$��0,0,31,0q�U �� *
IsReadOnly+< �� *TemplatedParent+�� $ focused��8��	 $��1��$y�	Collapsed=�$��2���� $ disabled��8��
 $y�	Collapsed=�$��2��V P� % �@��HasItems& .  . ��� $W DropDownBorder�� � ��$ 95���� " ��.���  � ��$ 6,1,6,3q���  � ��$ 0q���  � ��$ 14.667(���  � ��$ Segoe UI)���  � ��$ 30����  � ��8   ��  � ��8  ��  � ��8  ��  � ��8  ��  � ��$
 Auto=���  � ��$
 Auto=���  � �� . ��  �@��PanningMode$
 Both=���  �@��IsFlicksEnabled .  ��  � ��$ Center=���  � �� �� " ��.R�� $ MainGrid�� . ' �� $��* ��� $��30��$��0 �   CommonStates��.   
Normal��  	MouseOver��.	 �� .��T� $ (UIElement.Visibility)�$ hover��..�i� $ 0��  Visible=�T� $
 0D�$ 
Foreground�$ contentControl��..�i� $ 0��8    Disabled��.	 �� .��T� $ (UIElement.Visibility)�$ disabled��..�i� $ 0��  Visible=�  FocusStates��.   	Unfocused��  Focused��.	 �� .��T� $ (UIElement.Visibility)�$ focused��..�i� $ 0��  Visible=�  FocusedDropDown��.	 �� .��T� $ (UIElement.Visibility)�$ focused��..�i� $ 0��  Visible=�.+��� $ normal��8�� 8�� $��1��$��2���� $ hover��8�� 8�� $��1��$y�	Collapsed=�$��2��� $J 
PART_Popup��K . $��2��$��1q�#��� .�$��Bottom=����� *IsDropDownOpen+< �� *TemplatedParent+.���� $L DropDownBorder��$��Stretch=�8��	 8��
 $��1q�#��zM $N 2������ *ActualWidth+$O MainGrid��._��� $I DropDownScrollViewer��8�� .��� $P Enabled=�.+��� $
��Left=�$��0��$	��Top=�$��0��.+��� $ 
OpaqueRect������ *
Background+$O DropDownBorder������ *ActualHeight+$O DropDownBorder������ *ActualWidth+$O DropDownBorder���� $Q ItemsPresenter��$R 	Contained=�# z d� #��z��#��z��$��2��8�� S �� *IsDropDownOpen+$; TwoWay=�< �� *TemplatedParent+�� $X contentControl��#��z��#��z��#��z��#��z��Y .  .���� #��zZ #��z��#��z[ #] z\ # z #��z��#��z���� $ focused��8�� $��1��$y�	Collapsed=�$��2���� $ disabled��8�� $y�	Collapsed=�$��2��V P� % �@��HasItems& .  . ��� $W DropDownBorder�� � ��$ 95��P� % � {�& .  . ��� 8   � ���� 8   � ��P� % �@��
IsGrouping& . . ���  � �� .  P� $^ DropDownScrollViewer��% � ��& .  . ��� $W 
OpaqueRect�� �� *VerticalOffset+$O DropDownScrollViewer�� �@��Top�� $W 
OpaqueRect�� �� *HorizontalOffset+$O DropDownScrollViewer�� �@��Left$ P� % �@��
IsEditable& . . ���  � �� .  ��  � ��$ 0q���  � ��8  �� " ��.���  � ��$ 1q���  � ��8   ��  � ��$ 14.667(���  � ��$ Segoe UI)���  � ��8  ��  � ��8  ��  � ��$ 30����  � ��$	 6,3q���  �@��SelectionBrush8  ��  �@=�ErrorTemplate8  ��  � �� �� " ��.R�� $ RootElement�� .    CommonStates��.   
Normal��  	MouseOver��.	 �� .��T� $
 0D�$ BorderBrush�$ Border��..�i� $ 0��8  T� $
 0D�$ 
Background�$ Border��..�i� $ 0��8    Disabled��.	 �� .��W� $
 0D�$D 1X�$ Opacity�$ DisabledVisualElement��  ReadOnly��.	 �� .��W� $
 0D�$D 1X�$ Opacity�$ ReadOnlyVisualElement��  FocusStates��.   Focused��.	 �� .��W� $
 0D�$D 1X�$ Opacity�$ FocusVisualElement��  	Unfocused��.	 �� .��W� $
 0D�$D 0X�$ Opacity�$ FocusVisualElement��  ValidationStates��.   	Valid��  InvalidUnfocused��.	 �� .��T� $ 
Visibility�$ ValidationErrorElement��..�i� $ 0��  Visible=�  InvalidFocused��.	 �� .��T� $ 
Visibility�$ ValidationErrorElement��..�i� $ 0��  Visible=�T� $ IsOpen�$ validationTooltip��..�i� $ 0�� ��True��.+��� $L Border��#��z��#��z��#��z��$) 1Q�._�� .+��� $L ReadOnlyVisualElement��8�� $) 0Q��� $I PART_ContentHost��$��0q���.  #��z���� $L DisabledVisualElement��8�� #��z��8��	 Y .  $) 0Q��� $L FocusVisualElement��8��
 #��z��Y .  $) 0Q��� $L ValidationErrorElement��8�� #��z��$y�	Collapsed=�_ _� $` validationTooltip��$a Right=�8�� b �� < �� *TemplatedParent+c �� < �� *TemplatedParent+._�� 
������ $��Right=�$��12��$��	1,-4,-4,0q�$	��Top=�$��12��.+�F� ;����@B     р�[     � z �� ��� �� �J]� z ��j 	8�� $��1,3,0,0q�F� +����        р�     � z ��[ � z  z 	8�� $��1,3,0,0q��� " ��.���  � ��$ 0q���  � ��8   ��  � ��8  ��  � ��8  ��  � ��$
 Left=���  � ��$	 Top=���  � �� .  ��  � ��$ 1q���  � ��8  ��  � ��$
 Auto=���  � ��$
 Auto=���  � �� �� " ��.R��    ValidationStates��.   	Valid��  InvalidUnfocused��.	 �� .��T� $ 
Visibility�$ ValidationErrorElement��..�i� $ 0��  Visible=�  InvalidFocused��.	 �� .��T� $ 
Visibility�$ ValidationErrorElement��..�i� $ 0��  Visible=�T� $ IsOpen�$ validationTooltip��..�i� $ 0�� ��True��.+��� #��z��#��z��#��z��._��� $I ScrollViewer��$��0q�#��z��8�� .���� �� $L ValidationErrorElement��8�� #��z��$N 2��$y�	Collapsed=�_ _� $` validationTooltip��$a Right=�8�� b �� < �� *TemplatedParent+c �� < �� *TemplatedParent+d :� $e Canvas.Loaded��.[��� .���� .��T� $ IsHitTestVisible�$ validationTooltip��..�i� $ 0�� ��true��._�� 8�� $��Right=�$��10��$��	0,-4,-4,0q�$	��Top=�$��10��.+�F� ;����@B     р�[     � z �� ��� �� �J]� z ��j 	8�� $��-1,3,0,0q�F� +����        р�     � z ��[ � z  z 	8��	 $��-1,3,0,0q�