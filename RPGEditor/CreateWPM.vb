Imports Orc.Wizard

Public Class CreateWPM
    Inherits WizardPageBase
    Public Sub New()
        Title = "Person"
        Description = "Enter the details of the person"
    End Sub

    Public Property FirstName() As String
        Get
            Return m_FirstName
        End Get
        Set
            m_FirstName = Value
        End Set
    End Property
    Private m_FirstName As String

    Public Property LastName() As String
        Get
            Return m_LastName
        End Get
        Set
            m_LastName = Value
        End Set
    End Property
    Private m_LastName As String

    Public Overrides Function GetSummary() As ISummaryItem
        Return New SummaryItem() With {
            .Title = "Person",
            .Summary = String.Format("{0} {1}", FirstName, LastName)
        }
    End Function
End Class
