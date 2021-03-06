﻿using CTF_GAME.Model.ElementsMaps;
using CTF_GAME.Model.Exception;
using CTF_GAME.Model.FightsAttack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace CTF_GAME.Controllers
{
    public class FightsController
    {
        private CubeEnemy mobs;

        private readonly Random Random = new Random();

        public FightsController(AbstractMobsOnMap hero, AbstractMobsOnMap enemy)
        {
            mobs.hero = hero;
            mobs.enemy = enemy;
        }

        /// <summary>
        /// Процесс боя между двумя мобами карты, если игрок выйграл, то возвращет true
        /// </summary>
        /// <param name="action">действие от игрока</param>
        /// <returns>Сообщает, победил ли игрок</returns>
        public ResponseFights FightsDo(string action)
        {
            if (int.TryParse(action, out int numberTechniquesAttack) && numberTechniquesAttack >= 0 && numberTechniquesAttack < mobs.hero.attacksTechniques.Count)
            {
                mobs = FightsDo(mobs.hero, mobs.enemy, mobs.hero.attacksTechniques[numberTechniquesAttack]);
                //Если будет время, то стоит написать нормальный ИИ
                if (mobs.enemy.HealthPoint > 0)
                    mobs = FightsDo(mobs.enemy, mobs.hero, mobs.enemy.attacksTechniques[Random.Next(0, mobs.enemy.attacksTechniques.Count - 1)]);
            }
            if (mobs.hero.HealthPoint <= 0)
                throw new GameEndException("The desert has swallowed you up, wanderer.");
            else if (mobs.enemy.HealthPoint <= 0)
                return new ResponseFights() { winPlayers = true, response = mobs.enemy.GetASCIIArtEnd };
            else
                return new ResponseFights() { winPlayers = false };
        }

        /// <summary>
        /// Применяем аттаку, учитывая все свойства аттакующего и защищающегося
        /// </summary>
        /// <param name="mobsAttacks">моб который аттакует</param>
        /// <param name="mobsDefens">моб который защищается</param>
        /// <param name="action">какая атака будет применяться</param>
        /// <returns></returns>
        private CubeEnemy FightsDo(AbstractMobsOnMap mobsAttacks, AbstractMobsOnMap mobsDefens, IAttack action)
        {
            int random = Random.Next(1, 100);
            //Рассчитываем выпал смог ли моб уклониться
            if (mobsDefens.ChangeDodge <= random)
            {
                random = Random.Next(1, 100);
                //Рассчитываем выпал ли нам крит, если да, то получем 2 и умножаем её на общий дамаг
                int isCriticalDamage = (mobsAttacks.ChangeCriticalDamage + (((float)(100 - mobsAttacks.ChangeCriticalDamage) / 100) * action.ChangeCritical)) >= random ? 2 : 1;
                float factorArmor = ((float)(100 - mobsDefens.Armor) / 100);
                float commonDamage = (float)((action.Damage + mobsAttacks.Damage) * isCriticalDamage) * factorArmor;
                //Округляем в меньшую сторону
                mobsDefens.HealthPoint -= (int)commonDamage;
            }
            return mobs;

        }


        /// <summary>
        /// Структура с 2 мобами, с которыми происходит взаимодействие
        /// </summary>
        private struct CubeEnemy
        {
            public AbstractMobsOnMap hero;

            public AbstractMobsOnMap enemy;
        }

        /// <summary>
        /// Структура, возвращающаяся после каждого боя(атаки)
        /// </summary>
        public struct ResponseFights
        {
            public static implicit operator bool(ResponseFights x)
            {
                return x.winPlayers;
            }

            public static implicit operator string(ResponseFights x)
            {
                return x.response;
            }

            public bool winPlayers;

            public string response;
        }
    }
}
