using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBirdConsole
{
    static class ASCIICommon
    {
        private static readonly char inv = GameConsole.CHAR_INVISIBLE;
        public static char[,] getBigDigit(int num)
        {
            switch (num)
            {
                case 0:
                    return new char[,]{ 
                    {inv, inv, '_', '_', '_', inv, inv },
                    { inv, '/', ' ', '_', ' ', '\\', inv },
                    { '|', ' ', '|', inv, '|', ' ', '|' },
                    { '|', ' ', '|', inv, '|', ' ', '|' },
                    { '|', ' ', '|', '_', '|', ' ', '|' },
                    { inv, '\\', '_', '_', '_', '/', inv } };
                case 1:
                    return new char[,]{
                    {inv, '_', '_', inv  },
                    {'/', '_', ' ', '|' },
                    {inv, '|', ' ', '|' },
                    {inv, '|', ' ', '|' },
                    {inv, '|', ' ', '|' },
                    {inv, '|', '_', '|' } };
                case 2:
                    return new char[,]{
                    {inv, '_', '_', '_', inv, inv },
                    {'|', '_', '_', ' ', '\\', inv },
                    {inv, inv, inv, ')', ' ', '|' },
                    {inv, inv, '/', ' ', '/', inv },
                    {inv, '/', ' ', '/', '_', inv },
                    {'|', '_', '_', '_', '_', '|' } };
                case 3:
                    return new char[,]{
                    {inv, '_', '_', '_', '_', inv, inv },
                    {'|', '_', '_', '_', ' ', '\\', inv },
                    {inv, inv, '_', '_', ')', ' ', '|' },
                    {inv, '|', '_', '_', ' ', '<', inv },
                    {inv, '_', '_', '_', ')', ' ', '|' },
                    {'|', '_', '_', '_', '_', '/', inv } };
                case 4: return new char[,]{
                    { inv, '_', inv, inv, '_', inv, inv, inv },
                    { '|', ' ', '|', '|', ' ', '|' , inv, inv },
                    { '|', ' ', '|', '|', ' ', '|', '_', inv },
                    { '|', '_', '_', ' ', ' ', ' ', '_', '|' },
                    { inv, inv, inv, '|', ' ', '|', inv, inv },
                    { inv, inv, inv, '|', '_', '|', inv, inv } };
                case 5: return new char[,]{
                    {inv, '_', '_', '_', '_', '_', inv },
                    {'|', ' ', '_', '_', '_', '_', '|' },
                    {'|', ' ', '|', '_', '_', inv, inv },
                    {'|', '_', '_', '_', ' ', '\\', inv },
                    {inv, '_', '_', '_', ')', ' ', '|' },
                    {'|', '_', '_', '_', '_', '/', inv } };
                case 6: return new char[,]{
                    {inv, inv, inv, '_', '_', inv, inv },
                    {inv, inv, '/', ' ', '/', inv, inv },
                    {inv, '/', ' ', '/', '_', inv, inv },
                    {'|', ' ', '\'', '_', inv, '\\', inv },
                    {'|', ' ', '(', '_', ')', ' ', '|' },
                    {inv, '\\', '_', '_', '_', '/', inv } };
                case 7: return new char[,] {
                    {inv, '_', '_', '_', '_', '_', '_', inv },
                    {'|', '_', '_', '_', '_', ' ', ' ', '|' },
                    {inv, inv, inv, inv, '/', ' ', '/', inv },
                    {inv, inv, inv, '/', ' ', '/', inv, inv },
                    {inv, inv, '/', ' ', '/', inv, inv, inv },
                    {inv, '/', '_', '/', inv, inv, inv, inv } };
                case 8: return new char[,]{
                    {inv, inv, '_', '_', '_', inv, inv },
                    {inv, '/', ' ', '_', ' ', '\\', inv },
                    {'|', ' ', '(', '_', ')', ' ', '|' },
                    {inv, '>', ' ', '_', ' ', '<', inv },
                    {'|', ' ', '(', '_', ')', ' ', '|' },
                    {inv, '\\', '_', '_', '_', '/', inv } };
                case 9: return new char[,] {
                    {inv, inv, '_', '_', '_', inv, inv },
                    {inv, '/', ' ', '_', ' ', '\\',inv },
                    {'|', ' ', '(', '_', ')', ' ', '|' },
                    {inv, '\\', '_', '_', ',', ' ', '|' },
                    {inv, inv, ' ', '/', ' ', '/', inv },
                    {inv, inv, '/', '_', '/', inv, inv } };

                default: return getBigDigit(0);
            }
        }

    }
}
