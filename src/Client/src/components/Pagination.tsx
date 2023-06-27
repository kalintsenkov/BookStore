import React, { useCallback, useEffect, useState } from 'react';

import useTheme from '../hooks/useTheme';

interface IPaginationProps {
  page: number;
  totalPages: number;
  radius?: number;
  onPageSelected: (page: number) => void;
}

interface ILink {
  text: string;
  page: number;
  enabled: boolean;
  active: boolean;
}

const Pagination = ({ page = 1, totalPages, radius = 3, onPageSelected }: IPaginationProps): JSX.Element => {
  const { theme } = useTheme();
  const [links, setLinks] = useState<ILink[]>([]);

  const loadPages = useCallback(() => {
    const previous = 'Previous';
    const next = 'Next';
    const isPreviousPageLinkEnabled = page !== 1;
    const previousPage = page - 1;

    const linkList: ILink[] = [
      {
        page: previousPage,
        enabled: isPreviousPageLinkEnabled,
        text: previous,
        active: false
      }
    ];

    for (let i = 1; i <= totalPages; i++) {
      if (i >= page - radius && i <= page + radius) {
        linkList.push({
          page: i,
          active: page === i,
          enabled: true,
          text: i.toString()
        });
      }
    }

    const isNextPageLinkEnabled = page !== totalPages;
    const nextPage = page + 1;

    linkList.push({
      page: nextPage,
      enabled: isNextPageLinkEnabled,
      text: next,
      active: false
    });

    setLinks(linkList);
  }, [page, totalPages, radius]);

  useEffect(() => {
    loadPages();
  }, [page, totalPages, radius, loadPages]);

  const selectedPageInternal = async (link: ILink) => {
    if (link.page === page || !link.enabled) {
      return;
    }

    page = link.page;

    await onPageSelected(link.page);
  };

  const getLinkClassName = (link: ILink) => {
    let className = '';
    if (!theme) {
      className = 'bg-light text-black';
      if (link.active) {
        className = 'bg-light-primary text-white fw-bold';
      }
      if (!link.enabled) {
        className = 'bg-light text-gray';
      }
    } else {
      className = 'bg-dark text-white';
      if (link.active) {
        className = 'bg-dark-primary text-black fw-bold';
      }
      if (!link.enabled) {
        className = 'bg-dark text-gray';
      }
    }

    return className;
  };

  return (
    <>
      {totalPages !== 0 && (
        <nav className='mt-4 d-flex justify-content-center'>
          <ul className='pagination'>
            {links.map((link, index) => (
              <li
                key={index}
                onClick={() => selectedPageInternal(link)}
                style={{ cursor: link.enabled ? 'pointer' : 'not-allowed' }}
                className={`page-item ${!link.enabled ? 'disabled' : ''} ${link.active ? 'active' : ''}`}
              >
                <span className={`${getLinkClassName(link)} page-link border-0`}>
                  {link.text}
                </span>
              </li>
            ))}
          </ul>
        </nav>
      )}
    </>
  );
};

export default Pagination;