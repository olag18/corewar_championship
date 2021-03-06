/* ************************************************************************** */
/*                                                                            */
/*                                                        :::      ::::::::   */
/*   algen.h                                            :+:      :+:    :+:   */
/*                                                    +:+ +:+         +:+     */
/*   By: hmassonn <hmassonn@student.42.fr>          +#+  +:+       +#+        */
/*                                                +#+#+#+#+#+   +#+           */
/*   Created: 2017/10/20 13:43:50 by hmassonn          #+#    #+#             */
/*   Updated: 2017/10/23 15:35:27 by hmassonn         ###   ########.fr       */
/*                                                                            */
/* ************************************************************************** */

#ifndef ALGEN_H
# define ALGEN_H

# include <stdlib.h>
# include <unistd.h>
# include <fcntl.h>
# include <errno.h>
# include <dirent.h>
# include <time.h>
# include <grp.h>
# include <pwd.h>
# include <stdio.h>
# include <sys/stat.h>
# include <sys/xattr.h>
# include <sys/types.h>
# include <sys/time.h>
# include <uuid/uuid.h>
# include "libft.h"

#define POP_SIZE	42
#define N_KIN		10
#define N_CHILD		10
#define N_TARGET	1
#define PATH_CHAMPIONSHIP "champions/"
#define DELTA_US_MAX 500000
// #define MV_ALL_FILE		for f in *.cor.dmp; do mv "$f" "`echo $f | sed s/.cor.dmp/.s/`"; done

typedef struct			s_resu
{
	int					cursor;
	char				res[5051][4];
	char				champ[POP_SIZE + 1];
}						t_resu;

/*
**		dans main.c
*/

void	cursor_plus();
void	cursuor_mod(int who, int val);

/*
**		dans initial.c
*/

// void	create_champ_header(int fd, char name[19]);
// void	create_champ(int fd);
void	assemble(char name[19]);
void	initial(char **av, char ***pool);

/*
**		dans ft_tools.c
*/

void 	my_error(char *str);
char	*catch_signal(int signal);
char	*my_fork(char *cmd, char **args, char **ev);

#endif
