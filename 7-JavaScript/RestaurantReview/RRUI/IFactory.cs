namespace RRUI
{
    public interface IFactory
    {
        IMenu GetMenu(MenuType p_menu);
    }
}