using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;

// ����� �������� �� ���� ������ ��������������� ��������� �������
// ����� ���������. �������� �������� ���� ���������, ����� �������� ��������,
// ��������� �� �������.
[assembly: AssemblyTitle("MixSoft")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("MixSoft�")]
[assembly: AssemblyProduct("MixSoft")]
[assembly: AssemblyCopyright("Sunrise Studios � 2020")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

//����� ������ �������� ������������ ����������, �������
//<UICulture>CultureYouAreCodingWith</UICulture> � ����� .csproj
//� <PropertyGroup>. ��������, ��� ������������� ����������� (���)
//� ����� �������� ������ ���������� <UICulture> � en-US.  ����� �������� �������������� � �����������
//�������� NeutralResourceLanguage ����.  �������� "en-US" �
//������ ����� ��� ����������� ������������ ��������� UICulture � ����� �������.

//[assembly: NeutralResourcesLanguage("en-US", UltimateResourceFallbackLocation.Satellite)]


[assembly: ThemeInfo(
    ResourceDictionaryLocation.None, //��� ����������� ������� �������� �� ���������� ���������
                                     //(������������, ���� ������ �� ������ �� ��������,
                                     // ��� � �������� �������� ����������)
    ResourceDictionaryLocation.SourceAssembly //��� ���������� ������� ������������� ��������
                                              //(������������, ���� ������ �� ������ �� ��������,
                                              // � ���������� ��� � �����-���� �������� �������� ��� ���������� ����)
)]


// �������� � ������ ��� ������ �������� ������ ��������� ��������:
//
//      �������� ����� ������
//      �������������� ����� ������
//      ����� ������
//      ����� ��������
//
// ����� ������ ��� �������� ��� ������� ������ ������ � �������� �� ��������� 
// ��������� "*", ��� �������� ����:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("3.1")]
[assembly: AssemblyFileVersion("3.1")]
