/* ************************************************************************** */
/*                                                                            */
/*                                                        :::      ::::::::   */
/*   ft_exit.c                                          :+:      :+:    :+:   */
/*                                                    +:+ +:+         +:+     */
/*   By: clanier <clanier@student.42.fr>            +#+  +:+       +#+        */
/*                                                +#+#+#+#+#+   +#+           */
/*   Created: 2017/03/07 12:02:49 by clanier           #+#    #+#             */
/*   Updated: 2017/10/23 20:52:36 by hmassonn         ###   ########.fr       */
/*                                                                            */
/* ************************************************************************** */

#include "corewar.h"

void	ft_stop_sound(t_mars *mars)
{
	float	vol;

	vol = 1.f;
	(void)mars;
	// while ((vol -= 0.0000001f) >= 0)
	// 	FMOD_ChannelGroup_SetVolume(mars->sound->channelgroup, vol);
	// FMOD_Sound_Release(mars->sound->sound);
	// FMOD_System_Close(mars->sound->system);
	// FMOD_System_Release(mars->sound->system);
}

void	ft_draw_skull_head(t_mars *mars)
{
	if (mars->last_live == 1)
		mars->last_live = 0x00ff00;
	else if (mars->last_live == 2)
		mars->last_live = 0x0000ff;
	else if (mars->last_live == 3)
		mars->last_live = 0xff0000;
	else
		mars->last_live = 0xff00ff;
	ft_reset_top_grid(mars);
	ft_draw_skull_1(mars);
	ft_draw_skull_2(mars);
	ft_draw_skull_3(mars);
	ft_draw_skull_4(mars);
	ft_reset_btm_grid(mars);
	ft_draw_info(&mars);
	ft_flush(mars);
	usleep(3000000);
	if (mars->opt & 0b01000000)
		ft_stop_sound(mars);
}

void	ft_print_winner(t_mars *mars, t_cpu *cpu)
{
	t_cpu	*lst;

	mars->process = 0;
	if ((mars->opt & 0b1))
		ft_display_mars(&mars, cpu);
	lst = cpu;
	while (lst)
	{
		if (lst->uid == mars->last_live)
		{
			mars->last_live = lst->color;
			// printf("le joueur %d(%s) a gagne\n", lst->color, lst->name);
			// g_champ.res[g_champ.cursor][2] = lst->color;
			// g_champ.cursor++;
			cursuor_mod(2, lst->color);
			cursor_plus();
			break ;
		}
		lst = lst->next;
	}
	if (mars->opt & 0b10)
		ft_draw_skull_head(mars);
}
