   M S B A M L   `   `   `  ���� E  ACourseWork, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:CourseWork
CourseWork  5clr-namespace:CourseWork.ModelsCourseWork.Models      CourseWork.MainWindow   a ]Syncfusion.Shared.Wpf, Version=19.1460.0.64, Culture=neutral, PublicKeyToken=3d67ed1f87d44c892
Syncfusion!http://schemas.syncfusion.com/wpf  W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     *localclr-namespace:CourseWork     1modelclr-namespace:CourseWork.Models     b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -     � Title$  Interpol��$	��450��$	��800��.��� .+��� .@��� -    ��Name$ 	Criminals��$��Злочинці��.���  � RowDefinitions �� $
��0.2* �$��50���� $
��0.8* ��� $
��0.1* �$��50��.+���  �� Orientation$ 
Horizontal=�$��0��.+��� -    ��Name$ filterCriminalsTextBox��$	��100��$	��200��$��10q��� -    ��Name$ filterCriminalsComboBox��$	��100��$	��200��$��40 10 10 10q��� -    ��Name$ criminalsScrollView��$��1��$��10q�$��Visible=�.��&   System.Windows.Controls.DataGrid  -     Name$ criminalsDataGrid��   AutoGenerateColumns .  	 J� IsManipulationEnabled	 . ���� 
 � 	Resources
    rowContextMenu m�Name��%�   &	        �� @�m� $ editCriminalMenuItem��-   $��Редагувати��m� $" showCriminalsDetailsMenuItem��-   $��Детальніше��m� $# moveCriminalToArchiveMenuItem��-	   $(��"Відправити у архів��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ ID��   
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding ��  �� Path$ IDstring�  $ Ім'я�� .  �� $ 	FirstName�  $ Прізвище�� .  �� $ LastName�  $ Прізвисько�� .  �� $ NickName�  $ 
Зріст�� .  �� $ Height�  $ Колір волосся�� .  �� $ 	HairColor�  $ Колір очей�� .  �� $ EyeColor�  $' !Особливі прикмети�� .  �� $ DistinctiveFeatures�  $ Громадянство�� .  �� $ Citizenship�  $% Місце народження�� .  �� $ 
BirthPlace�  $# Дата народження�� .  �� $ 	BirthDate�  $4 .Останнє місце проживання�� .  �� $ LastDomicile�  $- 'Кримінальна професія�� .  �� $ CriminalSpecialization�  $! Остання справа�� .  �� $ LastCase�  $ Мови�� .  �� $ 	Languages�   RowStyle ��  �� 
TargetType)  #System.Windows.Controls.DataGridRow"   �� BasedOn# [B .���  �� Property �@�ContextMenu �� Value# [  �� $��2��.+��� -
    ��Name$ addCriminalButton��$	��150��$��Додати запис��$��Bottom=�$��Right=��� -   $ Bands��$#��Банди злочинців��.���  �� $
��0.2* �$��50���� $
��0.8* ��� $
��0.1* �$��50��.+��� $ 
Horizontal=�$��0��.+��� -   $ filterBandsTextBox��$	��100��$	��200��$��10q��� -   $ filterBandsComboBox��$	��100��$	��200��$��40 10 10 10q��� -   $ bandsScrollView��$��1��$��10q�$��Visible=�.��  -   $ bandsDataGrid�� .  	 . ���� 
 ��%�   &	        �� @�m� $ editBandMenuItem��-   $��Редагувати��m� $! showBandDetailsBandMenuItem��-   $��Детальніше��   $ ID�� .  �� $ IDstring�  $ 
Назва�� .  �� $
 Name�  $! Рід діяльності�� .  �� $ 
Occupation�  $ 
Члени�� .  �� $ MembersString�  $- 'Додаткова інформація�� .  �� $ AdditionalInfo� �� "  # [B .���  �@�ContextMenu# [  �� $��2��.+��� -   $ addBandButton��$	��150��$��Додати запис��$��Bottom=�$��Right=��� -   $ Archive��$#��Архів злочинців��.���  �� $
��0.2* �$��50���� $
��0.9* �.+��� $ 
Horizontal=�$��0��.+��� -   $# filterCriminalsArchiveTextBox��$	��100��$	��200��$��10q��� -   $$ filterCriminalsArchiveComboBox��$	��100��$	��200��$��40 10 10 10q��� -   $  criminalsArchiveScrollView��$��1��$��10q�$��Visible=�.��  -   $ criminalsArchiveDataGrid�� .  	 . ���� 
 ��%�   &	        �� @�m� $! editCriminalArchiveMenuItem��-   $��Редагувати��m� $) #showCriminalsDetailsArchiveMenuItem��-   $��Детальніше��m� $! moveBackFromArchiveMenuItem��-   $&�� Повернути до бази��   $ ID�� .  �� $ IDstring�  $ Ім'я�� .  �� $ 	FirstName�  $ Прізвище�� .  �� $ LastName�  $ Прізвисько�� .  �� $ NickName�  $ 
Зріст�� .  �� $ Height�  $ Колір волосся�� .  �� $ 	HairColor�  $ Колір очей�� .  �� $ EyeColor�  $' !Особливі прикмети�� .  �� $ DistinctiveFeatures�  $ Громадянство�� .  �� $ Citizenship�  $% Місце народження�� .  �� $ 
BirthPlace�  $# Дата народження�� .  �� $ 	BirthDate�  $4 .Останнє місце проживання�� .  �� $ LastDomicile�  $- 'Кримінальна професія�� .  �� $ CriminalSpecialization�  $! Остання справа�� .  �� $ LastCase�  $ Мови�� .  �� $ 	Languages� �� "  # [B .���  �@�ContextMenu# [  �� -   $ ChangesConfirm��$��
Зміни��.���  �� $
��0.2* �$��50���� $
��0.9* �.+��� $ 
Horizontal=�$��0��.+��� -   $ filterChangesTextBox��$	��100��$	��200��$��10q��� -   $ filterChangesComboBox��$	��100��$	��200��$��40 10 10 10q��� -   $ changesScrollView��$��1��$��10q�$��Visible=�.��  -   $ changesDataGrid�� .  	 . ���� 
 ��%�   &	        �� @�m� $ applyChangeMenuItem��-    $��Схвалити��m� $ deleteChangeMenuItem��-!   $��Відхилити��m� $ showChangeMenuItem��-"   $��Детальніше��   $ 
Автор�� .  �� $ Author�  $ Тип зміни�� .  �� $ TypeToString�  $+ %Запис, що змінюється�� .  �� $ RecordIDstring� �� "  # [B .���  �@�ContextMenu# [  �� -#   $ ChangesArchive��$��Архів змін��.���  �� $
��0.2* �$��50���� $
��0.9* �.+��� $ 
Horizontal=�$��0��.+��� -$   $! filterChangesArchiveTextBox��$	��100��$	��200��$��10q��� -%   $" filterChangesArchiveComboBox��$	��100��$	��200��$��40 10 10 10q��� -&   $ changesArchiveScrollView��$��1��$��10q�$��Visible=�.��  -'   $ changesArchiveDataGrid�� .  	 . ���� 
 ��%X   &	        �� @�m� $ showChangeArchiveMenuItem��-(   $��Детальніше��   $ 
Автор�� .  �� $ Author�  $ Тип зміни�� .  �� $ TypeToString�  $+ %Запис, що змінюється�� .  �� $ RecordIDstring� �� "  # [B .���  �@�ContextMenu# [  �� -)   $ Users��$��Користувачі��.���  �� $
��0.2* �$��50���� $
��0.9* �.+��� $ 
Horizontal=�$��0��.+��� -*   $ filterUsersTextBox��$	��100��$	��200��$��10q��� -+   $ filterUsersComboBox��$	��100��$	��200��$��40 10 10 10q��� -,   $ usersScrollView��$��1��$��10q�$��Visible=�.��  --   $ usersDataGrid�� .  	 . ���� 
 ��%d   &	        �� @�m� $ promoteToAdminMenuItem��-.   $)��#Надати адмін. права��   $$ Ім'я користувача�� .  �� $ Username�  $ Статус�� .  �� $
 Role� �� "  # [B .���  �@�ContextMenu# [  �� -/   $ Account��$��Акаунт��.���  �� $
��0.5* �$��50���� $
��0.5* ��� $
��0.2* �$��50��.+��� -0    ��Name$ userNameTextBlock��$��0��$%��Ім'я користувача:��$��10q�$��20(��� -1   $ userRoleTextBlock��$��1��$��	Роль:��$��10q�$��20(��� -2   $ logOutButton��$��2��$��
Вийти��$	��100��$��Right=�$��10q�